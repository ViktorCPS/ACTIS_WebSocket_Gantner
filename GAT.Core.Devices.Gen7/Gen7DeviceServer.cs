using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GAT.Core.Devices.Gen7
{
    public class Gen7DeviceServer : Gen7Device
    {
        public Gen7DeviceServer(ILogger logger, WebSocket socket) : base(logger)
        {
            _webSocket = socket;
        }

        /// <summary>
        /// Start to listen for data from device. In case connection gets closed this method will continue
        /// or throw an exception.
        /// </summary>
        /// <returns>Task to wait until device is disconnected.</returns>
        /// <exception cref="Exceptions.ConnectionErrorException">This exception is thrown when connection did not get closed gradually. See inner exception for more information.</exception>
        public async Task Start()
        {
            await ReceiveLoop();
        }
    }
}
