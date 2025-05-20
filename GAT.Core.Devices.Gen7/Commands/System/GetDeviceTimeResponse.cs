namespace GAT.Core.Devices.Gen7.Commands.System
{
    public class GetDeviceTimeResponse : Response
    {
        [CommandName("System.GetDeviceTime")]
        public string Time { get; set; }

        public string TimeUtc { get; set; }
    }
}
