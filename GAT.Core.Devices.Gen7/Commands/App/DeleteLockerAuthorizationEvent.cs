using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// Deletes a list of lockers for the current card. used in gt7 central
    /// </summary>
    [CommandName("App.DeleteLockerAuthorizations")]
    public class DeleteLockerAuthorizationEvent : Event
    {
        #region Properties

        /// <summary>
        /// List of Locks to delete
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> Locks { get; set; }

        /// <summary>
        /// The card uid to delete
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UID { get; set; } = null;

        #endregion Properties
    }
}
