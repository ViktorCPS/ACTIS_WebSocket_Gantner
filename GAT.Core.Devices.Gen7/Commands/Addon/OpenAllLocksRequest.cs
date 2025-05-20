using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("Addon.OpenAllLocks")]
    public class OpenAllLocksRequest : Request
    {
        public List<string> Controllers { get; set; }
    }
}
