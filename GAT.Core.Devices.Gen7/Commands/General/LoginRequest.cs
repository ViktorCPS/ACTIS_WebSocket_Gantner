using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("Login")]
    public class LoginRequest : Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OneTimeToken { get; set; } = null;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; } = null;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; } = null;

        /// <summary>
        /// Gets or sets if the device is in transparent mode.
        /// The device is considered as online when OnlineDecision is true and the host software is registered to the App.* event.
        /// Only one software is allowed to take decisions.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? OnlineDecision { get; set; }

        /// <summary>
        /// Gets or sets the host software info (My Software - Vx.x.x)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Info { get; set; }

    }
}
