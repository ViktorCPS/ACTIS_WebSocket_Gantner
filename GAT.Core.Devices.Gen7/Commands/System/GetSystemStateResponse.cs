namespace GAT.Core.Devices.Gen7.Commands.System
{
    [CommandName("System.GetSystemState")]
    public class GetSystemStateResponse : Response
    {
        public bool HostConnection { get; set; }
        public string HostInfo { get; set; }
        public bool CloudConnection { get; set; }
        public bool WlanConnected { get; set; }
        public string WlanIpAddress { get; set; }
        public string LanIpAddress { get; set; }
        public bool FiuReady { get; set; }
        public bool Touch { get; set; }
        public bool CameraReady { get; set; }
        public bool NtpSynchronized { get; set; }
        public long UpTime { get; set; }
        public long UpTimeHost { get; set; }
        public long UpTimeOS { get; set; }
    }
}
