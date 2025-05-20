using Newtonsoft.Json;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartUnlockProcess")]
    public class StartUnlockProcessRequest : Request
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UnlockingTime_ms { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Relay> Relays { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; }

        public class Relay
        {
            public int Id { get; set; }
            public int OnTime_ms { get; set; }
        }
    }
}
