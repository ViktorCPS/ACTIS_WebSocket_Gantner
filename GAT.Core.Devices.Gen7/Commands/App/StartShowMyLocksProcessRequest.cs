using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    public enum CardType
    {
        Standard,
        Maintenance
    }

    [CommandName("App.StartShowMyLocksProcess")]
    public class StartShowMyLocksProcessRequest : Request
    {

        #region Constructors

        public StartShowMyLocksProcessRequest(string uid)
        {
            UID = uid;
        }

        #endregion Constructors

        #region Properties

        [JsonConverter(typeof(StringEnumConverter))]
        public CardType CardType { get; set; }

        /// <summary>
        /// Optional: white list of locks which the uid is allowed to use
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> DynamicLocksAllowed { get; set; }

        /// <summary>
        /// Optional: list of locks which the uid is using at the time of the command. Also lockers that are not on this terminal can be included.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> DynamicLocksInUse { get; set; }

        /// <summary>
        /// Optional: UID has access to free mode locks. if not set the free locker mode is disabled (=false).
        /// </summary>
        public bool FreeLockerModeEnabled { get; set; }

        /// <summary>
        /// Optional: list of locks which the uid is using at the time of the command. Also lockers that are not on this terminal can be included.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> FreeLocksAllowed { get; set; }

        /// <summary>
        /// Optional: white list of locks which the uid is allowed to use
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> FreeLocksInUse { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> MaintenanceLocks { get; set; }

        /// <summary>
        /// Gets or sets if the user can handle lockers without pin
        /// </summary>
        public bool NoPinRequired { get; set; }

        /// <summary>
        /// Optional: list of all personal locks. Can include locks from other terminal. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Lock> PersonalLocks { get; set; }

        /// <summary>
        /// Hashed pincode for MFA
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets if the user has to change the pin on next usage
        /// </summary>
        public bool RenewPinRequired { get; set; }

        /// <summary>
        /// Gets or sets the UID of the card which started the process
        /// </summary>
        public string UID { get; set; }

        #endregion Properties
    }
}
