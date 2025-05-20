using System;
using System.Collections.Generic;
using System.Text;

namespace GAT.Core.Devices.Gen7.Commands.System
{
    [CommandName("System.SetHostInfo")]
    public class SetHostInfoRequest : Request
    {
        /// <summary>
        /// True: The management software will answer requests from the app.
        /// </summary>
        public bool OnlineDecision { get; set; }
        /// <summary>
        /// Host software info.
        /// </summary>
        public string Info { get; set; }
    }
}
