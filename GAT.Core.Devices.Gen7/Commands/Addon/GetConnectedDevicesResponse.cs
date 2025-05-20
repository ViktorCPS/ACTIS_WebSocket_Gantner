using GAT.Core.Devices.Gen7.Commands.General;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("Addon.GetConnectedDevices")]
    public class GetConnectedDevicesResponse : Response
    {
        public List<Device> Devices { get; set; }
    }

}
