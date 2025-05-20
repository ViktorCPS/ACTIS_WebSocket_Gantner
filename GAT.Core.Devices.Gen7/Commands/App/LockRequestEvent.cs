using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.LockRequest")]
    public class LockRequestEvent : Event
    {
        /// <summary>
        /// Gets or sets the card uid
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// Gets or sets the rf standard.
        /// </summary>

        [DefaultValue(RfStandards.UNKNOWN)]
        [JsonConverter(typeof(DefaultUnknownEnumConverter))]
        public RfStandards RfStandard { get; set; }
        /// <summary>
        /// Gets or sets the card segments.
        /// </summary>

        public List<Segment> Segments { get; set; }


        /// <summary>
        /// Id of the Lock,
        ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
        /// Use <see cref="Channel"/>, <see cref="ControllerArticleNumber"/>  and <see cref="ControllerSerialNumber"/> to use the parsed values.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = null;
        /// <summary>
        /// (optional) Locker Number if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public uint? Number { get; set; } = null;
        /// <summary>
        /// (optional) Locker Group if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public uint? Group { get; set; } //= null;
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestTypes Request { get; set; }

        public enum RequestTypes
        {
            Lock,
            Unlock
        }
    }
}
