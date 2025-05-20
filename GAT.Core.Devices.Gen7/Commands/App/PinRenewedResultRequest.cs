using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [CommandName("App.PinRenewedResult")]
    public class PinRenewedResultRequest : Request
    {

        /// <summary>
        /// New pin in hashed format
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PIN { get; set; } = null;

        /// <summary>
        /// The card uid to assign the pin
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UID { get; set; } = null;

        /// <summary>
        /// Pin successfully renewed
        /// </summary>
        public bool RenewedSuccessful { get; set; }
    }
}
