using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GAT.Core.Devices.Gen7.Gen7Event" />
    [CommandName("App.CardIdent")]
    public class CardIdentEvent : Event
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
        /// the current display language of the device
        /// </summary>
        public string Language { get; set; } = "en";
        /// <summary>
        /// Gets or sets the type of the card.
        /// </summary>
        [DefaultValue(CardTypes.UNKNOWN)]
        [JsonConverter(typeof(DefaultUnknownEnumConverter))]
        public CardTypes CardType { get; set; }
        /// <summary>
        /// Gets or sets the card segments.
        /// </summary>
        public List<Segment> Segments { get; set; }

    }
}
