using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Replace data carrier number in use.
    /// </summary>
    [CommandName("App.SetLockAuthorization")]
    public class SetLockAuthorizationRequest : Request
    {
        /// <summary>
        /// (optional) Id of the Lock,
        ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = null;
        /// <summary>
        /// (optional) Locker Number if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Number { get; set; }
        /// <summary>
        /// (optional) Locker Group if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Group { get; set; }

        /// <summary>
        /// Gets or sets the card uid as hex string. MSB first.
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// Gets or sets the rf standard. 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RfStandards RfStandard { get; set; } = RfStandards.UNKNOWN;
    }
}
