using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// https://portal.gantner.com/display/0000000000GT7/05.01.10+App.Locks.SetAntennaMatching
    /// </summary>
    [CommandName("App.Locks.SetAntennaMatching")]
    public class SetAntennaMatchingRequest : Request
    {
        /// <summary>
        /// (optional) Id of the Lock
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        /// <summary>
        /// (optional) Locker number if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }
        /// <summary>
        /// (optional) Locker group if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Group { get; set; }
        /// <summary>
        /// undefined: auto adjust antenna
        /// 0-15 set custom antenna matching value
        /// </summary>
        public string Value { get; set; }
    }
}
