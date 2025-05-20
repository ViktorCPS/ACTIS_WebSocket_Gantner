using System;
using System.Net.Security;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GAT.Core.Devices.Gen7
{
    public class Gen7DeviceClient : Gen7Device
    {
        private HeartbeatGenerator _heartbeatGenerator = null;
        private readonly ILogger _logger;
        private System.Timers.Timer _reconnectTimer;

        private readonly SemaphoreSlim _semaphoreReconnect = new SemaphoreSlim(1, 1);

        #region Constructors

        public Gen7DeviceClient(ILogger logger) : base(logger)
        {
            _reconnectTimer = new System.Timers.Timer() { AutoReset = false };
            _reconnectTimer.Interval = 10000;
            _reconnectTimer.Elapsed += _reconnectTimer_Elapsed;
            _reconnectTimer.Start();
            _logger = logger;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// In which interval the device will try to reconnect
        /// </summary>
        public double ReconnectInterval { get => _reconnectTimer.Interval; set => _reconnectTimer.Interval = value; }

        public Uri Uri { get; private set; }
        public string AccessToken { get; private set; }

        public bool HasToReconnect { get; set; } = true;

        public DateTime? CertificateValidUntil { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Connects the specified remote location.
        /// </summary>
        /// <param name="remoteLocation">The remote location. Ip address or hostname</param>
        /// <returns></returns>
        public async Task ConnectAsync(string remoteLocation, bool isTlsActive, string accessToken = null, int? port = null)
        {
            Uri uri;

            if (isTlsActive)
            {
                if (port != null)
                {
                    uri = new Uri($"wss://{remoteLocation}:{port}/api");
                }
                else
                {
                    uri = new Uri($"wss://{remoteLocation}/api");
                }
            }
            else
            {
                if (port != null)
                {
                    uri = new Uri($"ws://{remoteLocation}:{port}/api");
                }
                else
                {
                    uri = new Uri($"ws://{remoteLocation}/api");
                }
            }

            await ConnectAsync(uri, accessToken, hasLostConnection: false);
        }

        /// <summary>
        /// Connect the device to the specified uri.
        /// </summary>
        /// <param name="uri">The URI. format: ws://{remoteLocation}/api</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">websocket already open</exception>
        public virtual async Task ConnectAsync(Uri uri, string accessToken = null, bool hasLostConnection = false)
        {
            HasToReconnect = true;
            //remember uri for reconnect
            Uri = uri;

            //open socket
            ClientWebSocket webSocket = new ClientWebSocket();

            // Disable keep alive to prevent deadlock in SendAsync(). This only happens with .net framework but not with .net core!
            // Keep alive is not required as heartbeat is implemented in G7 protocol.
            // https://developercommunity.visualstudio.com/content/problem/620090/race-condition-in-clientwebsocket-when-using-keep.html
            webSocket.Options.KeepAliveInterval = TimeSpan.Zero;

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                AccessToken = accessToken;
                webSocket.Options.SetRequestHeader("Authorization", AccessToken);
                //remember access token for reconnect
            }

            // Wait 500 ms if the Gateway response tak 502 Code and tries Connect again

            _webSocket = webSocket;

            // get certificate of tls connection
            X509Certificate2 certificate = null;
            webSocket.Options.RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                certificate = new X509Certificate2(cert);
                return sslPolicyErrors == SslPolicyErrors.None;
            };

            //if _websocket is set, reconnect will be activated
            //webSocket.Options.RemoteCertificateValidationCallback += (sender, cert, chain, errors) => true;
            try
            {
                await webSocket.ConnectAsync(uri, CancellationToken.None);
                //start listening async
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ReceiveLoop());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                //heartbeat
                if (_heartbeatGenerator == null)
                {
                    _heartbeatGenerator = new HeartbeatGenerator(this);
                    await _heartbeatGenerator.StartAsync();
                }

                if (certificate != null)
                {
                    CertificateValidUntil = certificate.NotAfter;
                }

                base.OnConnectionStateChanged(isConnected: true, hasLostConnection: hasLostConnection);
            }
            catch (System.Net.WebSockets.WebSocketException)
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

                throw;
            }
            catch (Exception ex)
            {
                try
                {
                    _logger.LogError(ex, $"Unhandled Exception occured during connect. uri: {uri}");
                    CancellationTokenSource source = new CancellationTokenSource(500);
                    await _webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "CU", source.Token);
                }
                catch (Exception ex2)
                {
                    _logger.LogWarning(ex2, $"failed to close connection after failed connect. uri: {uri}");
                }
                try
                {
                    _webSocket.Dispose();
                }
                catch (ObjectDisposedException dispEx)
                {
                    _logger.LogDebug(dispEx.Message, dispEx);
                }
                _webSocket = null;
            }
        }

        protected override async Task ProcessEnvelope(Envelope envelope)
        {
            await base.ProcessEnvelope(envelope);

            //Re-register after reconnect
            //could be moved to client in future. maybe not needed on server?
            if (envelope.MT == Envelope.MessageTypes.Rsp
                && envelope.Cmd == "Login"
                && envelope.State.HasValue
                && envelope.State == 0
                )
            {
                ReRegisterEventsOnDevice();
            }
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        public override async Task DisconnectAsync()
        {
            try
            {
                _semaphoreReconnect.Wait(2000);
                HasToReconnect = false;

                if (_heartbeatGenerator != null)
                {
                    _heartbeatGenerator.Stop();
                }

                _reconnectTimer.Stop();

                await base.DisconnectAsync();
            }
            finally
            {
                _semaphoreReconnect.Release();
            }
        }

        /// <summary>
        /// Connects the specified URI. format of uri ws://0.0.0.0/api
        /// </summary>
        private async void _reconnectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _semaphoreReconnect.Wait();

                if ((_webSocket == null || _webSocket.State == WebSocketState.Aborted)
                    && HasToReconnect)
                {
                    try
                    {
                        if(_webSocket != null)
                        {
                            _webSocket.Dispose();
                            _webSocket = null;
                        }
                        await ConnectAsync(Uri, AccessToken, hasLostConnection: true);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogDebug($"Could not reconnect channel {Uri} ", ex);
                    }
                }
            }
            finally
            {
                _reconnectTimer.Start();
                try
                {
                    _semaphoreReconnect.Release();
                }
                catch
                {
                    _logger.LogError("Could not release semaphore");
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                return _webSocket != null && (_webSocket.State == WebSocketState.Open);
            }
        }

        #endregion Methods
    }
}