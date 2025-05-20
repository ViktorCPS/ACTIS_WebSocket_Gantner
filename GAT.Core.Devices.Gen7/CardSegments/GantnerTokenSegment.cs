using System;

namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class GantnerTokenSegment : Segment
    {
        public string FID { get; set; }
        public string ID { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }

        public DateTime MessageTimeStamp { get; set; }
        public override SegmentTypes SegmentType { get; set; } = SegmentTypes.GANTNER_TOKEN;
    }
}
