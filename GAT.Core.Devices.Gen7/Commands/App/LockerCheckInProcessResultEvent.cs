namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.LockerCheckInProcessResult")]
    public class LockerCheckInProcessResultEvent : Event
    {
        /// <summary>
        /// Gets or sets a value indicating whether the locker check in was successful.  Returns true if successful
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// Gets or sets the number of successful written locker segments
        /// </summary>
        public int SuccessCount { get; set; }
    }
}
