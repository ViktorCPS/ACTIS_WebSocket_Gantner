using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="GetTaABookingsRequest"/>.
    /// </summary>
    [CommandName("App.GetBookings")]
    public class GetTaABookingsResponse : Response
    {
        /// <summary>
        /// Gets or sets the total count of bookings in this response.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the the found bookings.
        /// </summary>
        public List<Booking> Bookings { get; set; }
    }
}