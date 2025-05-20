using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartIdentProcess")]
    public class StartIdentProcess : Request
    {
        /// <summary>
        /// Optional: Timeout in ms
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Timeout_ms { get; set; }
        /// <summary>
        /// Optional: Override default display text. Html possible.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; }
        /// <summary>
        /// Optional: Override default screen symbol.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }
    }
}
