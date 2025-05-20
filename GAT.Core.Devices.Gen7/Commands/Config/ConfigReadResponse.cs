using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Config
{
    [CommandName("Config.Read")]
    public class ConfigReadResponse : Response
    {
        public List<ParameterGroup> ParameterGroups { get; set; }

        public class ParameterGroup
        {
            public string Group { get; set; }
            public bool? IsEnabled { get; set; } = null;
            public bool? IsInherited { get; set; } = null;

            public JObject Parameters { get; set; }

            public DateTime Timestamp { get; set; }
        }
    }
}
