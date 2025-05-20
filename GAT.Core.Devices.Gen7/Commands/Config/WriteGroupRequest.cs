using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Config
{
    [CommandName("Config.WriteGroup")]
    public class WriteGroupRequest : Request
    {
        public string Group { get; set; }
        public bool IsEnabled { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
