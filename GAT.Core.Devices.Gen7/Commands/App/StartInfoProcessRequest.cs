using Newtonsoft.Json;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartInfoProcess")]
    public class StartInfoProcessRequest : Request
    {
        /// <summary>
        /// Gets or sets the display text for page 1.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText1 { get; set; }
        /// <summary>
        /// Gets or sets the display text for page 2.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText2 { get; set; }
        /// <summary>
        /// Gets or sets the display text for page 3.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText3 { get; set; }
        /// <summary>
        /// Gets or sets the display text for page 4.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText4 { get; set; }

        /// <summary>
        /// Optional: Data to display in the @Table wildcard.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<object> OnlineData { get; set; }

        /// <summary>
        /// Optional: Icon to display at sceen. Default: "info". Use "" for no icon. (Font Awesome 5 icon name)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IconName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="StartInfoProcessRequest"/> is accepted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if accepted; otherwise, <c>false</c>.
        /// </value>
        public bool Accepted { get; set; }
    }
}
