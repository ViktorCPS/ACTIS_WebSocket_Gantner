using GAT.Core.Devices.Gen7.Commands.General;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.LockStateChanged")]
    public class LockStateChangedEvent : Event
    {
        public Lock Lock { get; set; }

        public ActionResults ActionResult { get; set; }

        public enum ActionResults
        {
            Ok,
            LockFailed,
            UnlockFailed,
            CommError
        }
    }
}
