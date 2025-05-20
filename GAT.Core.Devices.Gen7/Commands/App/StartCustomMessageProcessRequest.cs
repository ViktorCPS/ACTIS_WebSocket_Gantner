using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary></summary>
    [CommandName("App.StartCustomMessageProcess")]
    public class StartCustomMessageProcessRequest : Request
    {
        /// <summary></summary>
        public string DisplayText { get; set; } = "";
        /// <summary></summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TextColor { get; set; } = null;
        /// <summary></summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; } = null;
        /// <summary></summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IconClass { get; set; } = null;
        /// <summary></summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IconColor { get; set; } = null;
        /// <summary></summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LedColor { get; set; } = null;
        /// <summary>Duration in milliseconds </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; } = null;
    }
}
