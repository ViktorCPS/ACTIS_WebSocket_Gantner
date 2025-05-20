using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GAT.Core.Devices.Gen7.Commands;
using GAT.Core.Devices.Gen7.Commands.Config;
using GAT.Core.Devices.Gen7.Commands.General;
using GAT.Core.Devices.Gen7.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GAT.Core.Devices.Gen7
{
    public abstract class Gen7Device : IDisposable
    {
        #region Variables

        public WebSocket _webSocket;
        private List<EventListener> _eventListeners = new List<EventListener>();
        private ConcurrentDictionary<int, RequestMutex> _pendingRequests = new ConcurrentDictionary<int, RequestMutex>();
        private Dictionary<string, Func<Envelope, Task<Envelope>>> _requestListeners = new Dictionary<string, Func<Envelope, Task<Envelope>>>();
        private TransactionIdGenerator _transactionIdGenerator = new TransactionIdGenerator();
        private readonly ILogger _logger;
        private readonly SemaphoreSlim _semaphoreSendCommand = new SemaphoreSlim(1, 1);
        private CancellationTokenSource _cancelReceiveTokenSource = null;
        private List<string> _sensitiveCommandNames;

        #endregion Variables

        #region Events

        public event EventHandler<CommunicationEventArgs> CommunicationEvent;

        public event EventHandler<RequestHandledArgs> RequestHandled;

        public event EventHandler<ConnectionStateChangedArgs> ConnectionStateChanged;

        #endregion Events

        #region Constructors

        public Gen7Device(ILogger logger)
        {
            _logger = logger;

            _sensitiveCommandNames = new List<string>();

            _sensitiveCommandNames.Add((typeof(LoginRequest).GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute).Name);
            _sensitiveCommandNames.Add((typeof(SetPasswordRequest).GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute).Name);
        }

        #endregion Constructors

        #region Properties

        public int Timeout { get; set; } = 10000;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        public virtual async Task DisconnectAsync()
        {
            //check if sending is still in progress
            await _semaphoreSendCommand.WaitAsync(10000);

            try
            {
                if (_webSocket != null)
                {
                    CancellationTokenSource source = new CancellationTokenSource(5000);

                    try
                    {
                        try
                        {
                            await _webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "CU", source.Token);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message, ex);
                        }
                        _webSocket.Dispose();
                    }
                    catch (ObjectDisposedException ex)
                    {
                        _logger.LogDebug(ex.Message, ex);
                    }

                    _webSocket = null;
                    if (_cancelReceiveTokenSource != null)
                    {
                        // Give the device 1s to gradually close the connection. Otherwise force it by canceling the receive loop.
                        _cancelReceiveTokenSource.CancelAfter(1000);
                    }
                }
            }
            finally
            {
                _semaphoreSendCommand.Release();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_webSocket != null)
            {
                try
                {
                    _webSocket.Dispose();
                }
                catch (ObjectDisposedException ex)
                {
                    _logger.LogDebug(ex.Message, ex);
                }
                _webSocket = null;
            }

            _eventListeners.Clear();
            _requestListeners.Clear();

            if (_cancelReceiveTokenSource != null)
            {
                try
                {
                    _cancelReceiveTokenSource.Dispose();
                }
                catch (ObjectDisposedException ex)
                {
                    _logger.LogDebug(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Registers the event listener.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <exception cref="System.TypeLoadException">CommandNameAttribute is not set!</exception>
        public async Task RegisterEventListenerAsync<TEvent>(Func<TEvent, Task> handler)
        {
            CommandNameAttribute commandNameAttribute = typeof(TEvent).GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute;

            if (commandNameAttribute == null)
            {
                throw new TypeLoadException("CommandNameAttribute is not set!");
            }

            // internal handler -> call the given handler with the Body of the ICommand<T>.
            // this trick allows us to call an generic action in the "receive".
            Func<Envelope, Task> internalHandler = (x) => handler(x.Data.ToObject<TEvent>());
            EventListener listener = new EventListener(commandNameAttribute.Name, internalHandler);

            _eventListeners.Add(listener);

            //inform device that we want to listen to the event
            await RegisterEventOnDevice(commandNameAttribute.Name);
        }

        /// <summary>
        /// Registers a request listener.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <exception cref="System.TypeLoadException">
        /// CommandNameAttribute is not set for request!
        /// or
        /// CommandNameAttribute is not set for response!
        /// </exception>
        /// <exception cref="System.ArgumentException">Request is already registered. Only one listener per request is allowed. This will ensure that only one response is send to a request.</exception>
        public void RegisterRequestListener<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handler)
        {
            lock (_requestListeners)
            {
                CommandNameAttribute requestNameAttribute = typeof(TRequest).GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute;
                if (requestNameAttribute == null)
                {
                    throw new TypeLoadException("CommandNameAttribute is not set for request!");
                }

                CommandNameAttribute responseNameAttribute = typeof(TResponse).GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute;
                if (responseNameAttribute == null)
                {
                    throw new TypeLoadException("CommandNameAttribute is not set for response!");
                }

                if (_requestListeners.ContainsKey(requestNameAttribute.Name))
                {
                    throw new ArgumentException("Request is already registered. Only one listener per request is allowed. This will ensure that only one response is send to a request.");
                }
                // internal handler -> call the given handler with the Body of the ICommand<T>.
                // this trick allows us to call an generic action in the "receive".
                Func<Envelope, Task<Envelope>> internalHandler = async (x) =>
               {
                   Envelope envelopeResponse = new Envelope();
                   envelopeResponse.TID = x.TID;
                   envelopeResponse.GID = x.GID;
                   envelopeResponse.MT = Envelope.MessageTypes.Rsp;
                   envelopeResponse.Cmd = responseNameAttribute.Name;
                   try
                   {
                       TRequest data = default(TRequest);
                       if (x.Data != null)
                       {
                           data = x.Data.ToObject<TRequest>();
                       }
                       TResponse result = await handler(data);
                       if (result != null)
                       {
                           envelopeResponse.Data = JObject.FromObject(result);
                       }
                       envelopeResponse.State = 0;
                   }
                   catch
                   {
                       envelopeResponse.State = 1; //general error
                   }
                   return envelopeResponse;
               };
                _requestListeners.Add(requestNameAttribute.Name, internalHandler);
            }
        }

        public async Task SendEvent(Type typeOfEvent, object eventData)
        {
            CommandNameAttribute requestNameAttribute = typeOfEvent.GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute;
            if (requestNameAttribute == null)
            {
                throw new TypeLoadException("CommandNameAttribute is not set for event object!");
            }
            Envelope envelope = new Envelope();
            int tid = _transactionIdGenerator.GetTID();
            envelope.TID = tid;
            envelope.Data = JObject.FromObject(eventData);
            envelope.Cmd = requestNameAttribute.Name;
            envelope.MT = Envelope.MessageTypes.Evt;

            await SendCommand(envelope);
        }

        public async Task SendEvent<TEvent>(TEvent eventData)
        {
            await SendEvent(eventData.GetType(), eventData);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="responseType"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException">This exception is thrown when device doesn't return a successfull result.</exception>
        /// <exception cref="TimeoutException">This exception is thrown when device didn't respond within the sepcified <see cref="Timeout"/>.</exception>
        public async Task<object> SendRequestAsync(Type requestType, Type responseType, object request)
        {
            CommandNameAttribute requestNameAttribute = requestType.GetCustomAttributes(typeof(CommandNameAttribute), true).FirstOrDefault() as CommandNameAttribute;
            if (requestNameAttribute == null)
            {
                throw new TypeLoadException("CommandNameAttribute is not set for request!");
            }

            int tid = _transactionIdGenerator.GetTID();
            //create envelope and serialize the request into the data
            Envelope envelope = new Envelope();
            envelope.TID = tid;
            envelope.GID = Guid.NewGuid().ToString();
            envelope.Data = JObject.FromObject(request);
            envelope.Cmd = requestNameAttribute.Name;
            envelope.MT = Envelope.MessageTypes.Req;

            RequestMutex mutex = new RequestMutex(envelope);

            //"register" request mutex to the pending requests. If the response is read, the response is set and signaled. see also ProcessResponse
            _pendingRequests.TryAdd(tid, mutex);

            try
            {
                await SendCommand(envelope);

                if (await mutex.ResponseSignal.WaitAsync(Timeout) == false)
                {
                    throw new TimeoutException("Did not get a response in time.");
                };

                if (mutex.Response == null)
                {
                    // This is normally when connection get closed and all mutexes are released.
                    throw new TimeoutException("Response was not set.");
                }

                object data = mutex.Response?.Data?.ToObject(responseType);

                if (mutex.Response.State.HasValue == false)
                {
                    throw new RequestFailedException("Device returned with no state") { Data = data };
                }

                byte state = mutex.Response.State.Value;

                if (state == 0)
                {
                    return data;
                }
                else
                {
                    throw new RequestFailedException($"Device returned with error code {state}") { State = state, Data = data };
                }
            }
            catch (CouldNotSendCommandException ex)
            {
                throw new RequestFailedException("Failed to send gommand to device.", ex);
            }
            finally
            {
                _pendingRequests.TryRemove(tid, out _);
            }
        }

        /// <summary>
        /// Sends the request asynchronous.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.TypeLoadException">CommandNameAttribute is not set for request!</exception>
        /// <exception cref="System.Exception">
        /// Device returned with error code {state}
        /// or
        /// Device returned with no state
        /// </exception>
        /// <exception cref="System.TimeoutException">did not get a response in time</exception>
        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request)
        {
            return (TResponse)(await SendRequestAsync(typeof(TRequest), typeof(TResponse), request));
        }

        /// <summary>
        /// Starts loop to receive data.
        /// </summary>
        /// <returns>A task to wait until connection got closed.</returns>
        /// <exception cref="Exceptions.ConnectionErrorException">This exception is thrown when connection did not get closed gradually. See inner exception for more information.</exception>
        protected async Task ReceiveLoop()
        {
            try
            {
                _cancelReceiveTokenSource = new CancellationTokenSource();
                while (_webSocket.State == WebSocketState.Open)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);
                    WebSocketReceiveResult result = null;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        do
                        {
                            result = await _webSocket.ReceiveAsync(buffer, _cancelReceiveTokenSource.Token);
                            memoryStream.Write(buffer.Array, buffer.Offset, result.Count);
                        }
                        while (!result.EndOfMessage);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8))
                            {
                                // continue loop if end of stream is read.
                                if (reader.EndOfStream) continue;

                                string commandData = reader.ReadToEnd();
                                try
                                {
                                    Envelope envelope = (Envelope)JsonConvert.DeserializeObject(commandData, typeof(Envelope));

                                    string commandInsenstive = SerializeToInsensitive(envelope, commandData);
                                    _logger.LogDebug($"[I] {commandInsenstive}");
                                    OnCommunicationEvent(commandInsenstive, CommunicationEventArgs.Directions.Incoming);
                                    // Do processing asynchron because when any (request) handler issues and request, this will endup in an dead lock.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                                    if (envelope != null)
                                    {
                                        Task.Run(() => ProcessEnvelope(envelope));
                                    }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                                }
                                catch
                                {
                                    _logger.LogDebug($"[I] COULD NOT PARSE: {commandData}");
                                    OnCommunicationEvent($"COULD NOT PARSE: {commandData}", CommunicationEventArgs.Directions.Incoming);
                                }
                            }
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            break;
                        }
                    }
                }
                _logger.LogDebug("Closed");
            }
            catch (WebSocketException wex)
            {
                throw new ConnectionErrorException("Connection got closed", wex);
            }
            catch (OperationCanceledException oex)
            {
                throw new ConnectionErrorException("Waiting for data from socket got canceled.", oex);
            }
            finally
            {
                _cancelReceiveTokenSource.Dispose();
                _cancelReceiveTokenSource = null;

                OnConnectionStateChanged(isConnected: false, hasLostConnection: true);

                // Release all request mutexes becuase we will not receive any response as connection got closed.
                foreach (int pendingRequestKey in _pendingRequests.Keys.ToList())
                {
                    RequestMutex mutex;
                    if (_pendingRequests.TryGetValue(pendingRequestKey, out mutex))
                    {
                        try
                        {
                            mutex.ResponseSignal.Release();
                        }
                        catch (SemaphoreFullException ex)
                        {
                            _logger.LogWarning("Response already released", ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Send a <see cref="RegisterEventRequest"/> foreach registered event listener. <seealso cref="RegisterEventListenerAsync{TEvent}(Func{TEvent, Task})"/>
        /// </summary>
        protected void ReRegisterEventsOnDevice()
        {
            foreach (EventListener eventListener in _eventListeners)
            {
                // Fire and forget registering for events.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                RegisterEventOnDevice(eventListener.EventName);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        internal void OnConnectionStateChanged(bool isConnected, bool hasLostConnection = false)
        {
            ConnectionStateChanged?.Invoke(this, new ConnectionStateChangedArgs { IsConnected = isConnected, HasLostConnection = hasLostConnection });
        }

        protected virtual async Task ProcessEnvelope(Envelope gen7Envelope)
        {
            try
            {
                switch (gen7Envelope.MT)
                {
                    case Envelope.MessageTypes.Evt:
                        await ProcessEvent(gen7Envelope);
                        break;

                    case Envelope.MessageTypes.Req:
                        await ProcessRequest(gen7Envelope);
                        break;

                    case Envelope.MessageTypes.Rsp:
                        ProcessResponse(gen7Envelope);
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"failed to process envelope");
            }
        }

        private async Task ProcessEvent(Envelope gen7Envelope)
        {
            foreach (EventListener listener in _eventListeners.Where(x => x.EventName == gen7Envelope.Cmd))
            {
                await listener.InternalHandler(gen7Envelope);
            }
        }

        private async Task ProcessRequest(Envelope envelopeRequest)
        {
            Func<Envelope, Task<Envelope>> internalHandler;

            if (_requestListeners.TryGetValue(envelopeRequest.Cmd, out internalHandler))
            {
                Envelope envelopeResponse = await internalHandler(envelopeRequest);
                await SendCommand(envelopeResponse);
                OnRequestHandled(envelopeRequest, envelopeResponse);
            }
        }

        private void ProcessResponse(Envelope gen7Envelope)
        {
            if (gen7Envelope.TID.HasValue)
            {
                int tid = gen7Envelope.TID.Value;

                RequestMutex mutex;
                if (_pendingRequests.TryGetValue(tid, out mutex))
                {
                    try
                    {
                        mutex.Response = gen7Envelope;
                        mutex.ResponseSignal.Release();
                    }
                    catch (SemaphoreFullException ex)
                    {
                        _logger.LogWarning("Could not release response", ex);
                    }
                }
                else
                {
                    _logger.LogError($"no request was registered for response with TID {tid}");
                }
            }
            else
            {
                _logger.LogError("TID is missing in response!");
            }
        }

        private async Task RegisterEventOnDevice(string eventName)
        {
            if (_webSocket == null || _webSocket.State != WebSocketState.Open)
            {
                _logger.LogWarning("device not connected");
                return;
            }

            try
            {
                // App event can only be registered all or nothing
                if (eventName.StartsWith("App."))
                {
                    eventName = "App.*";
                }

                RegisterEventRequest registeEventRequest = new RegisterEventRequest() { Event = eventName };
                RegisterEventResponse response = await SendRequestAsync<RegisterEventRequest, RegisterEventResponse>(registeEventRequest);

                _logger.LogInformation(eventName + " was registered on device.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "could not register event");
                throw new Exception("could not register event", ex);
            }
        }

        /// <summary>
        /// Sends a command to a device.
        /// </summary>
        /// <param name="envelope">The command that will be sent to the device.</param>
        /// <exception cref="CouldNotSendCommandException">This exception is thrown whenever a command cannot be send to the device.</exception>
        private async Task SendCommand(Envelope envelope)
        {
            //make sure send command is only called once. sending to commands in parrallel will cause a System.AggregateException´.
            await _semaphoreSendCommand.WaitAsync();

            try
            {
                //serialize the envelope (including the already serialized data) and send it
                string command = JsonConvert.SerializeObject(envelope);

                //do not include sensitve data into logs,etc.
                string commandInsensitve = SerializeToInsensitive(envelope, command);

                if (_webSocket != null && _webSocket.State == WebSocketState.Open)
                {
                    _logger.LogDebug($"[O] {commandInsensitve}");
                    CancellationTokenSource source = new CancellationTokenSource();
                    source.CancelAfter(Timeout);

                    await _webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(command)), WebSocketMessageType.Text, true, source.Token);

                    OnCommunicationEvent(commandInsensitve, CommunicationEventArgs.Directions.Outgoing);
                }
                else
                {
                    _logger.LogError($"Could not send message to device. Web socket is not open. message: {commandInsensitve}");
                    throw new CouldNotSendCommandException("Could not send message to device because websocket is not open.");
                }
            }
            catch (WebSocketException ex)
            {
                _logger.LogError(ex, $"Could not send message to device. Web socket is not open.");
                throw new CouldNotSendCommandException("Could not send message to device.", ex);
            }
            catch (CouldNotSendCommandException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occured during sending a message to the device");
                throw new CouldNotSendCommandException("Could not send message to device", ex);
            }
            finally
            {
                _semaphoreSendCommand.Release();
            }
        }

        private string SerializeToInsensitive(Envelope envelope, string commandInput)
        {
            string retVal = commandInput;
            if (string.IsNullOrWhiteSpace(commandInput))
            {
                //_logger.LogError("empty input, envelope cannot contain sensitive information.");
            }
            else
            {
                try
                {
                    foreach (string commandName in _sensitiveCommandNames)
                    {
                        if (envelope.Cmd == commandName)
                        {
                            JObject envelopeJObject = JObject.Parse(commandInput);
                            JObject data = (JObject)envelopeJObject["Data"];

                            foreach (var item in data)
                            {
                                data[item.Key] = "***";
                            }
                            retVal = envelopeJObject.ToString(Formatting.None);
                            break; //command was found and obfuscated, skip any other command
                        }
                    }
                }
                catch (Exception)
                {
                    retVal = "Content omitted because of sensitive information";
                    //_logger.LogError(ex, "Could not obfuscate sensitive data.");
                }
            }

            return retVal;
        }

        private void OnCommunicationEvent(string commandData, CommunicationEventArgs.Directions direction)
        {
            CommunicationEvent?.Invoke(this, new CommunicationEventArgs() { Data = commandData, Direction = direction });
        }

        private void OnRequestHandled(Envelope request, Envelope response)
        {
            RequestHandled?.Invoke(this, new RequestHandledArgs { Request = request, Response = response });
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// used to invoke a registered event handler.
        /// </summary>
        private class EventListener
        {
            #region Constructors

            public EventListener(string commandName, Func<Envelope, Task> handler)
            {
                EventName = commandName;
                InternalHandler = handler;
            }

            #endregion Constructors

            #region Properties

            public string EventName { get; private set; }

            /// <summary>
            /// Gets the Handler to invoke. This is of type object because generics cannot be stored like "Action<CardIdentEvent>"
            /// </summary>
            public Func<Envelope, Task> InternalHandler { get; private set; }

            #endregion Properties
        }

        /// <summary>
        /// used to match request and response. if the response is retreived the ResponseSignal will be released.
        /// </summary>
        private class RequestMutex
        {
            #region Constructors

            public RequestMutex(Envelope request)
            {
                this.Request = request;
            }

            #endregion Constructors

            #region Properties

            public Envelope Request { get; set; }
            public Envelope Response { get; set; }

            /// <summary>
            /// Inidicates if the response was received.
            /// </summary>
            /// <value>
            /// The mutex.
            /// </value>
            public SemaphoreSlim ResponseSignal { get; set; } = new SemaphoreSlim(0, 1);

            #endregion Properties
        }

        #endregion Classes
    }
}
