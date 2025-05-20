using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    /// <summary>
    /// Class for the authentication for gen7 commands
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Gets or sets the card uid
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// Gets or sets the rf standard. 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RfStandards CardType { get; set; } = RfStandards.UNKNOWN;
    }
}
