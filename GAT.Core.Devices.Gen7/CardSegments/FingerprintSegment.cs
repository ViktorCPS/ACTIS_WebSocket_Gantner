using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class FingerprintSegment : Segment
    {
        public List<string> Templates { get; set; }
        public int VerificationLevel { get; set; }
        public override SegmentTypes SegmentType { get; set; } = SegmentTypes.FIU;
    }
}
