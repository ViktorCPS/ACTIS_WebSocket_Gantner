using ACTIS_WebSocket_Gantner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ACTIS_WebSocket_Gantner.Controllers
{
    [ApiController]
    [Route("ws/Device/")]
    public class DeviceController : Controller
    {
        private readonly ILoggerFactory _loggerFactory;
        public DeviceController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        [HttpGet("{deviceId?}")]
        public async Task<ActionResult> Device(string deviceId)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                if (HttpContext.Request.Headers["Authorization"] == "validAuthenticationToken")
                {
                    WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                    GT7Device device= new(_loggerFactory.CreateLogger<GT7Device>(),webSocket,deviceId);
                    await device.Start();
                    return base.Ok();
                }
                else
                {
                    return base.Forbid();
                }
            }
            else
            {
                return base.BadRequest();
            }
        }
    }
}
