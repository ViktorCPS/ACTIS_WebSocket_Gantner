using System;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("Heartbeat")]
    public class HeartbeatResponse : Response
    {
        /// <summary>
        /// Requested heartbeat interval in seconds
        /// </summary>
        public int HBI { get; set; }
        /// <summary>
        /// Current device time
        /// </summary>
        public DateTime RT { get; set; }
    }
}
