using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.Assignment.Upsert")]
    public class UpsertAssignmentRequest : Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizedObjectId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AuthorizedEntity> AuthorizedEntities { get; set; }

        public class AuthorizedEntity
        {
            public string Id { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidUntil { get; set; }
        }
    }
}
