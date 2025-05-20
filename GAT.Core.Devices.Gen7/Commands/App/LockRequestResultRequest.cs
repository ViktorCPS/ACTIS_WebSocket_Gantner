using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{

    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.LockRequestResult")]
    public class LockRequestResultRequest : Request
    {
        public LockRequestResultRequest()
        {

        }

        public LockRequestResultRequest(LockRequestEvent requestEvent)
        {
            UID = requestEvent.UID;
            Id = requestEvent.Id;
            Number = requestEvent.Number;
            Group = requestEvent.Group;
        }

        /// <summary>
        /// Gets or sets the card uid
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// Gets or sets the card segments to write on the card
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Segment> Segments { get; set; } = null;


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
        public uint? Group { get; set; } = null;
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultTypes Result { get; set; }

        /// <summary>
        /// Indicates if card had been identified by third party software as "MaintenanceCard".
        /// If false normal operation.
        /// If true the corresponding lock state change includes the card uid as MaintenanceCard Uid
        /// </summary>
        public bool IsMaintenance { get; set; } = false;

        /// <summary>
        /// result type 
        /// </summary>
        public enum ResultTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Deny,
            /// <summary>
            /// 
            /// </summary>
            Grant,
            /// <summary>
            /// 
            /// </summary>
            GrantWithMaster,
            /// <summary>
            /// TBD -> this value is not fixed yet!
            /// </summary>
            Autonom,
        }
    }
}
