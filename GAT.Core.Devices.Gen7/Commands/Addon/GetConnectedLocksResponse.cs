using GAT.Core.Devices.Gen7.Commands.General;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("Addon.GetConnectedLocks")]
    public class GetConnectedLocksResponse : Response
    {
        public List<Lock> Locks { get; set; }
    }
}
