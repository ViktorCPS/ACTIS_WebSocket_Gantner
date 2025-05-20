using GAT.Core.Devices.Gen7.Commands.CardNet.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Bookings.Get")]
    public class GetCardNetBookingsResponse : Response
    {
        #region Properties

        public List<CardNetBooking> Bookings { get; set; }

        #endregion Properties
    }
}
