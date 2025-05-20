using GAT.Core.Devices.Gen7.Commands.CardNet.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Authorizations.Get")]
    public class GetCardNetAuthorizationsResponse : Response
    {
        #region Properties

        public List<CardNetAuthorization> Authorizations { get; set; }

        #endregion Properties
    }
}
