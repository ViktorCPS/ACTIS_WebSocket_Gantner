namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to delete a single or multiple offline bookings from the terminal.
    /// </summary>
    [CommandName("App.DeleteBooking")]
    public class DeleteBookingRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the booking to delete. Ignored if ClearAll = true or Count > 0.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets whether to delete all existing bookings from the device.
        /// </summary>
        public bool ClearAll { get; set; }

        /// <summary>
        /// Gets or sets amount of bookings to delete. Ignored if ClearAll = true.
        /// </summary>
        public int Count { get; set; }
    }
}