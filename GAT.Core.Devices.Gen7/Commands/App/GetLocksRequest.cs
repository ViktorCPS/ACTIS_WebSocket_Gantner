using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.Locks.Get")]
    public class GetLocksRequest : Request
    {
        /// <summary>
        /// Id of the Lock,
        ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
        /// Use <see cref="Channel"/>, <see cref="ControllerArticleNumber"/>  and <see cref="ControllerSerialNumber"/> to use the parsed values.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = null;
    }
}
