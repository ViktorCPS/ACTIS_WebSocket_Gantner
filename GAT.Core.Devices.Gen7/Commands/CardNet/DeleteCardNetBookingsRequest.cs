namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Bookings.Delete")]
    public class DeleteCardNetBookingsRequest : Request
    {
        #region Properties

        /// <summary>
        /// Maximum numbers of bookings to delete
        /// </summary>
        public int Limit { get; set; }

        #endregion Properties
    }
}
