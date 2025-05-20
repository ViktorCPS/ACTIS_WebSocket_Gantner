using GAT.Core.Devices.Gen7.Commands.General;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// the v2 event does not include the locks
    /// </summary>
    /// <seealso cref="GAT.Core.Devices.Gen7.Gen7Event" />
    [CommandName("Addon.BusDevicesChangedV2")]
    public class BusDevicesChangedV2Event : Event
    {
        public List<Device> Devices { get; set; }
    }
}
