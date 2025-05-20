using GAT.Core.Devices.Gen7.Commands.CardNet.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Authorizations.Update")]
    public class UpdateCardNetAuthorizationsRequest : Request
    {
        #region Properties

        public List<CardNetAuthorization> Authorizations { get; set; }

        #endregion Properties
    }
}
