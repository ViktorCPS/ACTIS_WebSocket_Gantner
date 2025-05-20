using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Execute a locker action with an authorization
    /// </summary>
    [CommandName("App.Locks.Action")]
    public class LockerActionRequest : Request
    {
        /// <summary>
        /// Gets or sets the locker
        /// </summary>
        public Lock Lock { get; set; } = new Lock();

        /// <summary>
        /// Gets or sets the authentication
        /// </summary>
        public Authentication Authentication { get; set; } = new Authentication();

        /// <summary>
        /// Gets or sets the lock action
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LockerAction LockAction { get; set; }

        /// <summary>
        /// Enum of all LockerAction which are possible with this command
        /// </summary>
        public enum LockerAction
        {
            USER_LOCK,
            USER_UNLOCK,
            MASTER_LOCK,
            MASTER_UNLOCK,
            DISABLE_LOCK,
            ENABLE_LOCK,
            QUITE_ALARM_LOCK,
            ENABLE_MAINTANANCE_MODE,
            DISABLE_MAINTANANCE_MODE,
            ENABLE_RENTED_MODE,
            DISABLE_RENTED_MODE,
            SET_CONFIGURATION,
            SET_AUTHORIZATION
        }
    }
}
