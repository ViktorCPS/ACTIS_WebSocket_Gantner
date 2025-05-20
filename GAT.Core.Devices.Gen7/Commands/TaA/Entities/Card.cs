using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    public class Card
    {
        public string UID { get; set; }

        /// <summary>
        /// Gets or sets the rf standard.
        /// </summary>
        public RfStandards RfStandard { get; set; }

        /// <summary>
        /// Gets or sets 
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
