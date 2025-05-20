using GAT.Core.Devices.Gen7.Commands.General;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GAT.Core.Devices.Gen7
{
    /// <summary>
    /// used to send the heartbeat command 
    /// </summary>
    public class HeartbeatGenerator
    {
        #region Fields

        private readonly Gen7Device _device;
        private System.Timers.Timer _heartbeatTimer = new System.Timers.Timer() { AutoReset = false };
        private SemaphoreSlim _sendRestartLock = new SemaphoreSlim(1, 1);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatGenerator"/> class.
        /// </summary>
        /// <param name="device">The device.</param>
        public HeartbeatGenerator(Gen7Device device)
        {
            _heartbeatTimer.Elapsed += _heartbeatTimer_Elapsed;
            _device = device;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///  start sending the heartbeat. sending it for the first time and start a timer before returning.
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {

            await Task.Run(() => DoHeartbeat());
        }

        public async Task Stop()
        {
            try
            {
                await _sendRestartLock.WaitAsync();
                _heartbeatTimer.Stop();
            }
            finally
            {
                _sendRestartLock.Release();
            }
        }

        private void _heartbeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() => DoHeartbeat());
        }

        private async Task DoHeartbeat()
        {
            try
            {
                await _sendRestartLock.WaitAsync();
                int interval = 60; //seconds
                try
                {
                    //Don't try if websocket is closed
                    if (_device != null && _device._webSocket != null)
                    {
                        HeartbeatResponse heartbeatResponse = await _device.SendRequestAsync<HeartbeatRequest, HeartbeatResponse>(new HeartbeatRequest());
                        interval = heartbeatResponse.HBI;
                    }
                }
                catch (Exception)
                {
                    //heartbeat failed try again later
                }

                _heartbeatTimer.Interval = interval * 1000;
                _heartbeatTimer.Start();
            }
            finally
            {
                _sendRestartLock.Release();
            }
        }

        #endregion Methods
    }
}
