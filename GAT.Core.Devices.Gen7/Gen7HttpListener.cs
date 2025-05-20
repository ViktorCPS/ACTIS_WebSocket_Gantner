using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GAT.Core.Devices.Gen7
{
    public class Gen7HttpListener : Gen7Device
    {
        private HttpListener _httpListener;
        private int _port;

        public Gen7HttpListener(ILogger logger, int Port) : base(logger)
        {
            _port = Port;
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public async Task StartServer()
        {
            if (_httpListener != null)
            {
                if (_webSocket != null)
                {
                    _webSocket.Dispose();
                    _webSocket = null;
                }
                _httpListener.Stop();
                _httpListener = null;
            }
            HttpListenerContext listenerContext = await _httpListener.GetContextAsync();
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add($"http://+:{Port}/");
            _httpListener.Start();
            _webSocket = await GetWebSocket(listenerContext);
            if (_webSocket.State == WebSocketState.Open)
            {
                base.OnConnectionStateChanged(isConnected: true, hasLostConnection: false);
            }
        }

        private async Task<WebSocket> GetWebSocket(HttpListenerContext listenerContext)
        {
            WebSocket webSocket = null;
            WebSocketContext webSocketContext = null;
            try
            {
                webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
            }
            catch (Exception e)
            {
                // The upgrade process failed somehow. For simplicity lets assume it was a failure on the part of the server and indicate this using 500.
                listenerContext.Response.StatusCode = 500;
                listenerContext.Response.Close();
                return null;
            }
            _webSocket = webSocketContext.WebSocket;
            return webSocket;
        }

        public WebSocketState webSocketState
        {
            get { return _webSocket.State; }
        }

        public void RestartLoop()
        {
            StartServer();
        }

        public async Task StopServer()
        {
            if (_httpListener != null)
            {
                _httpListener.Close();
                _httpListener.Abort();
                _httpListener = null;
            }
        }

        /// <summary>
        /// Start to listen for data from device. In case connection gets closed this method will continue
        /// or throw an exception.
        /// For Relaxx G7 Connection
        /// </summary>
        /// <returns>Task to wait until device is disconnected.</returns>
        /// <exception cref="Exceptions.ConnectionErrorException">This exception is thrown when connection did not get closed gradually. See inner exception for more information.</exception>
        public async Task Start()
        {
            try
            {
                if (_httpListener != null)
                {
                    await StopServer();
                }
                _httpListener = new HttpListener();
                HttpListenerContext listenerContext = null;
                WebSocketContext webSocketContext = null;
                _httpListener.Prefixes.Add($"http://+:{Port}/");
                try
                {
                    _httpListener.Start();
                    listenerContext = await _httpListener.GetContextAsync();
                    webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
                }
                catch (Exception e)
                {
                    listenerContext.Response.StatusCode = 500;
                    listenerContext.Response.Close();
                    return;
                }
                _webSocket = webSocketContext.WebSocket;
                if (_webSocket.State == WebSocketState.Open)
                {
                    base.OnConnectionStateChanged(isConnected: true, hasLostConnection: false);
                    Task.Run(() => ReceiveLoop());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
