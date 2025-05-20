using GAT.Core.Devices.Gen7.Commands.General;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GAT.Core.Devices.Gen7.Gen7Event" />
    [CommandName("App.BusDevicesChanged")]
    public class BusDevicesChangedEvent : Event
    {
        public List<Device> Devices { get; set; }
    }
}
