using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartDurationSelectProcess")]
    public class StartDurationSelectProcessRequest : Request
    {
        /// <summary>
        /// Optional: Override default display text. Html possible.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; } = null;
        /// <summary>
        /// 	Optional: Duration of the base step in s
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? BaseTime { get; set; } = null;
        /// <summary>
        ///	Optional: Price of the base step
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? BasePrice { get; set; } = null;
        /// <summary>
        /// Optional: Duration of each step in s
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? StepTime { get; set; } = null;
        /// <summary>
        /// Optional: Max number of steps
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSteps { get; set; } = null;
        /// <summary>
        /// Optional: Price of each step
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StepPrice { get; set; } = null;
        /// <summary>
        /// Optional: Currency symbol
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; } = null;
    }
}
