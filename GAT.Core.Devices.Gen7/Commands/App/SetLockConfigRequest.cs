using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("App.SetLockConfig")]
    public class SetLockConfigRequest : Request
    {
        /// <summary>
        /// Id of the Lock,
        ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// (optional) Locker Number if configured
        /// </summary>
        public int NewNumber { get; set; }
        /// <summary>
        /// (optional) Locker Group if configured
        /// </summary>
        public int NewGroup { get; set; }
        /// <summary>
        /// (optional) Locker group record id if configured 
        /// </summary>
        public string NewLockerGroupRecordId { get; set; }
        /// <summary>
        /// (optional) Alphanumeric Locker Number 
        /// </summary>
        public string NewLabel { get; set; }
        /// <summary>
        /// mode of this lock
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Lock.LockerModes Mode { get; set; }
    }
}
