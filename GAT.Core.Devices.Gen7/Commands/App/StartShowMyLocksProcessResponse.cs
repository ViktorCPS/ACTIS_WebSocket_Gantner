using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartShowMyLocksProcess")]
    public class StartShowMyLocksProcessResponse : Response
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Timeout_ms { get; set; } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmByButton { get; set; } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmByCard { get; set; } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; } = null;
    }
}
