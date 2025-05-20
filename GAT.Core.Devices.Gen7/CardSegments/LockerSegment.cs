namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class LockerSegment : Segment
    {
        public int BatteryInfo { get; set; }
        /// <summary>
        /// 0 ... User Card
        /// </summary>
        public int CardType { get; set; }
        public bool CheckUseTime { get; set; }
        public bool Disabled { get; set; }
        /// <summary>
        /// Company ID
        /// </summary>
        public int FID { get; set; }
        public int Index { get; set; }
        public bool Locked { get; set; }
        public int LockerNumber { get; set; }
        public int LockerSegmentNumber { get; set; }
        /// <summary>
        /// Sub company id.Do not modify!
        /// </summary>
        public int SubFID { get; set; }
        public string TimeStampFirstUse { get; set; }
        public string TimeStampLastUse { get; set; }
        public int UseCounter { get; set; }
        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        public bool WasLocked { get; set; }
        public override SegmentTypes SegmentType { get; set; } = SegmentTypes.LOCKER;
    }
}
