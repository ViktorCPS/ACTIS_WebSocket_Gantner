namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to show a denied message to the user. Normally after a <see cref="PersonIdentEvent"/> was handled unsuccessfully.
    /// </summary>
    [CommandName("App.StartDenyProcess")]
    public class StartDenyProcessRequest : Request
    {
        /// <summary>
        /// Gets or sets the text message to show to the user.
        /// </summary>
        public string DisplayText { get; set; } = "Booking could not be created";

        /// <summary>
        /// Gets or sets an optional custom timeout for the message in ms.
        /// </summary>
        public int Timeout_ms { get; set; }

        /// <summary>
        /// Gets or sets an optional name of a custom icon to show to the user.
        /// </summary>
        public string IconName { get; set; }
    }
}