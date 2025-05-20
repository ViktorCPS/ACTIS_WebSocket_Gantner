using System;

namespace GAT.Core.Devices.Gen7.Commands.IO
{
    [CommandName("Locate")]
    [Obsolete("Use LocateDeviceRequst instead. This is only added for compatibility reasons.")]
    public class LocateEvent : Event
    {
        public bool Blink { get; set; } = true;
        public bool Beep { get; set; } = true;
        public int Timeout { get; set; } = 10;
    }
}
