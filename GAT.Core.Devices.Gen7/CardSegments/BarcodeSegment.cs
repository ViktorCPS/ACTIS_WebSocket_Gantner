namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class BarcodeSegment : Segment
    {
        /// <summary>
        /// Raw barcode data, if configured
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Extracted barcode id, if configured
        /// </summary>
        public string Id { get; set; }
        public override SegmentTypes SegmentType { get; set; } = SegmentTypes.BARCODE_DATA;
    }
}
