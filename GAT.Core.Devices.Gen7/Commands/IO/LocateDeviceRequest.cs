namespace GAT.Core.Devices.Gen7.Commands.IO
{
    [CommandName("IO.Locate")]
    public class LocateDeviceRequest : Request
    {
        public bool Blink { get; set; } = true;
        public bool Beep { get; set; } = true;
        public int Timeout { get; set; } = 10;
    }
}
