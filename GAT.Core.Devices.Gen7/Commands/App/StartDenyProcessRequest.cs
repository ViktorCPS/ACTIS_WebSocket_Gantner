using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartDenyProcess")]
    public class StartDenyProcessRequest : Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; }

    }
}
