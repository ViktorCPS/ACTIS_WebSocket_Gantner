namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.DurationSelected")]
    public class DurationSelectedEvent : Event
    {
        /// <summary>
        /// true: Duration selected
        /// false: Timeout or abort
        /// </summary>
        public bool Result { get; set; }
        public int Step { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the selected duration in seconds.
        /// </summary>
        public int Time { get; set; }
    }
}
