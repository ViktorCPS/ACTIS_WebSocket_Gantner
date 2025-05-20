using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartTimerProcess")]
    public class StartTimerProcessRequest : Request
    {
        /// <summary>
        /// Optional: Overwrite active time, default is the previous selected time.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Time { get; set; } = null;
    }
}
