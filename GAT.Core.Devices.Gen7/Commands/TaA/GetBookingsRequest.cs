namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to get offline bookings stored on the terminal.
    /// </summary>
    [CommandName("App.GetBookings")]
    public class GetTaABookingsRequest : Request
    {
        /// <summary>
        /// Gets or sets the amount of bookings to skip.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets the amount of bookings to fetch.
        /// </summary>
        public int Count { get; set; }
    }
}