namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to show a granted message to the user. Normally after a <see cref="PersonIdentEvent"/> was handled successfully.
    /// </summary>
    [CommandName("App.StartGrantProcess")]
    public class StartGrantProcessRequest : Request
    {
        /// <summary>
        /// Gets or sets the text message to show to the user.
        /// </summary>
        public string DisplayText { get; set; } = "Booking created";

        /// <summary>
        /// Gets or sets an optional custom timeout for the message in ms.
        /// </summary>
        public int Timeout_ms { get; set; }

        /// <summary>
        /// Gets or sets an optional name of a custom icon to show to the user.
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// Gets or sets an optional custom CSS class used to format the icon.
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets an optional custom sound file to play instead of the default one. Make sure, the sound file exists in the theme.
        /// </summary>
        public string SoundFile { get; set; }

        /// <summary>
        /// Optional and primary for internal use: If set to true, the App will handle the booking as if it was an offline booking.
        /// </summary>
        public bool Autonomous { get; set; }
    }
}