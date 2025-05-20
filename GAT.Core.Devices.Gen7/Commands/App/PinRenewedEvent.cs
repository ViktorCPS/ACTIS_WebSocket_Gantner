using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// Renew the pin for the given authorization. used in gt7 central
    /// </summary>
    [CommandName("App.PinRenewed")]
    public class PinRenewedEvent : Event
    {

        #region Properties

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

        #endregion Properties

    }
}
