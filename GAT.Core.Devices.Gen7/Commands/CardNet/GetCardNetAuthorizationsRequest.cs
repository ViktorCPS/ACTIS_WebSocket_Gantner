namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Authorizations.Get")]
    public class GetCardNetAuthorizationsRequest : Request
    {
        #region Properties

        public int Skip { get; set; }

        public int Count { get; set; }

        #endregion Properties
    }
}
