using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [CommandName("App.SetLockState")]
    public class SetLockStateRequest : Request
    {

        public string Id { get; set; } = null;
        public int? Number { get; set; } = null;
        public int? Group { get; set; } = null;

        public enum LockStates { Unlock, Lock }

        [JsonConverter(typeof(StringEnumConverter))]
        public LockStates? LockStatus { get; set; } = null;
        public bool? Enable { get; set; } = null;
        public bool? Maintenance { get; set; } = null;
        public bool? Rented { get; set; } = null;
        public bool? QuitAlarm { get; set; } = null;
    }
}
