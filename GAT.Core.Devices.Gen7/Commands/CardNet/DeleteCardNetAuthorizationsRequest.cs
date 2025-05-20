using GAT.Core.Devices.Gen7.Commands.CardNet.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.CardNet
{
    [CommandName("CardNET.Authorizations.Delete")]
    public class DeleteCardNetAuthorizationsRequest : Request
    {
        /// <summary>
        /// Whether to delete all authorizations, will be set to true if <see cref="Authorizations"/> is null or empty
        /// </summary>
        public bool ClearAll => Authorizations?.Count == 0;

        /// <summary>
        /// The list of authorizations to delete, leave null or empty to delete all
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<CardNetAuthorization> Authorizations { get; set; }
    }
}
