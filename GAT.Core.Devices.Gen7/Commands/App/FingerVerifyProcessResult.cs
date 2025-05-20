namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.FingerVerifyProcessResult")]
    public class FingerVerifyProcessResult : Event
    {
        public bool Match { get; set; }
    }
}
