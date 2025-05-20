using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.StartFingerVerifyProcess")]
    public class StartFingerVerifyProcessRequest : Request
    {
        public List<string> Templates { get; set; }
        public string DisplayText { get; set; } = "Fingerprint verification";

    }
}
