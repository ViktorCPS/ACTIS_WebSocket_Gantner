using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GAT.Core.Devices.Gen7.CardSegments
{
    [JsonConverter(typeof(SegmentConverter))]
    public abstract class Segment
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract SegmentTypes SegmentType { get; set; }

        public enum SegmentTypes
        {
            LOCKER,
            BARCODE_DATA,
            FIU,
            WIEGAND_DATA,
            GANTNER_TOKEN,
            CUSTOM
        }
    }
}
