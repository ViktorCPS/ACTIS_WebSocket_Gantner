using GAT.Core.Devices.Gen7.Commands.General;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.Locks.Get")]
    public class GetLocksResponse : Response
    {
        public List<Lock> Locks { get; set; }
    }
}
