using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using GAT.Core.Devices.Gen7;
using GAT.Core.Devices.Gen7.Commands.App;
using GAT.Core.Devices.Gen7.Commands.General;
using GAT.Core.Devices.Gen7.Commands.System;
using GAT.Core.Devices.Gen7.Exceptions;
using Microsoft.Extensions.Logging;

namespace ACTIS_WebSocket_Gantner
{
    public class GT7Device
    {
        private readonly ILogger<GT7Device> _logger;
        private readonly string _deviceId;
        private readonly Gen7DeviceServer _device;

        /// <summary>
        /// Constructor for GT7Device.
        /// </summary>
        /// <param name="logger">logger only be functional if a log4Net file exists. in this docu we dont implement the logger fake it for our GAT.Core.Devices.Gen7</param>
        /// <param name="webSocket">websocket connection with G7 device.</param>
        /// <param name="deviceId">optional device Id.</param>
        public GT7Device(ILogger<GT7Device> logger, WebSocket webSocket, string deviceId)
        {
            _logger = logger;
            _deviceId = deviceId;
            _device = new Gen7DeviceServer(logger, webSocket);
        }

        /// <summary>
        /// Start communication if a device will connect via Websocket.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            // communication only works after "_device.Start()" but first we register events and request for communication with devie.
            RegisterRequestsToListener();
            RegisterEventsToListener();
            GetDeviceInfoRequest();
            SetHostInfo();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await _device.Start();
        }

        /// <summary>
        /// Set the Host Info on Device, you can see it on webinterface of GT7 in OverView under connections
        /// </summary>
        /// <returns></returns>
        private async Task SetHostInfo()
        {
            await _device.SendRequestAsync<SetHostInfoRequest, SetHostInfoResponse>(new SetHostInfoRequest() { OnlineDecision = true, Info = "Online servis je aktivan!" });
        }


        /// <summary>
        /// Register Request to the Listener. in this case the listener is the Server.
        /// </summary>
        /// <returns></returns>
        private async Task RegisterRequestsToListener()
        {
            _device.RegisterRequestListener<HeartbeatRequest, HeartbeatResponse>(HandleHeartbeatRequest);

        }

        /// <summary>
        /// Register events to the Listner. the Listener in this case is the Server.
        /// </summary>
        /// <returns></returns>
        private async Task RegisterEventsToListener()
        {
            await _device.RegisterEventListenerAsync<CardIdentEvent>(HandleCardIdentEvent);
            await _device.RegisterEventListenerAsync<LockStateChangedEvent>(HandleLockStateChagnedEvent);
            await _device.RegisterEventListenerAsync<LockRequestEvent>(HandleLockRequestEvent);
        }


        /// <summary>
        /// here i show you how you can send request from server to the device. only sends if the device is open (after Start()).
        /// As an example we Get Device Info with the GetDeviceInfoRequest.
        /// </summary>
        /// <returns></returns>
        private async Task GetDeviceInfoRequest()
        {
            var response = await _device.SendRequestAsync<GetDeviceInfoRequest, GetDeviceInfoResponse>(new GetDeviceInfoRequest());
        }

        /// <summary>
        /// If a Device establish a connection successfully it will send any 30 or 60 seconds a Hearbeat. With the Heartbeat the server and the device knows if 
        /// connection is open. 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static async Task<HeartbeatResponse> HandleHeartbeatRequest(HeartbeatRequest arg)
        {
            HeartbeatResponse response = new()
            {
                HBI = 50,
                RT = DateTime.UtcNow
            };

            return response;
        }

        /// <summary>
        /// Anytime if a Lock state changes, a Device will send to the Server a LockstateChangedEvent
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        private async Task HandleLockStateChagnedEvent(LockStateChangedEvent @event)
        {
            // here implement logic of handling LockStateChangedEvent
        }

        /// <summary>
        /// LockRequestEvent will execute from device if you show Card directly to a locker.
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        private async Task HandleLockRequestEvent(LockRequestEvent lockRequestEvent)
        {

            // implement lockREquestEvent logic
        }

        /// <summary>
        /// CardidentEvent will be executed from device if you show Card directly by Terminal.
        /// </summary>
        /// <param name="cardIdentEvent"></param>
        /// <returns></returns>
        private async Task HandleCardIdentEvent(CardIdentEvent cardIdentEvent)
        {
            _logger.LogDebug($"Card ident received from {cardIdentEvent.UID}.");

            try
            {
                //GAT7Manager gtMng = new GAT7Manager();
                // // Check if user is allowed at a specific device.
                //if (gtMng.CheckTagOnGate(_deviceId, cardIdentEvent.UID))
                //{
                //    var response = await _device.SendRequestAsync<StartUnlockProcessRequest, StartUnlockProcessResponse>(new StartUnlockProcessRequest { DisplayText = "Pristup dozvoljen. Dobrodosli!", UnlockingTime_ms = 5000 });
                //    _logger.LogDebug("Pristup dozvoljen.");
                //}
                //else
                //{
                //    var response = await _device.SendRequestAsync<StartDenyProcessRequest, StartDenyProcessResponse>(new StartDenyProcessRequest { DisplayText = "Pristup nije dozvoljen!" });
                //    _logger.LogDebug("Pristup odbijen.");
                //}
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex, "Failed to handle card ident.");
            }
        }
    }
}