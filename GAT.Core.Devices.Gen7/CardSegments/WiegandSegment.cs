namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class WiegandSegment : Segment
    {
        public string SiteCode { get; set; }
        public override SegmentTypes SegmentType { get; set; } = SegmentTypes.WIEGAND_DATA;
    }
}
