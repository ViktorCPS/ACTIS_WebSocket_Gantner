using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [CommandName("App.DeleteLockerAuthorizationResult")]
    public class DeleteLockerAuthorizationResultRequest : Request
    {

        /// <summary>
        /// Locker to delete
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Lock Locks { get; set; }

        /// <summary>
        /// The card uid to delete
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UID { get; set; } = null;

        /// <summary>
        /// Lockerauthorization successfully deleted
        /// </summary>
        public bool ReleaseSuccessful { get; set; }
    }
}
