using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.AuthorizedEntities.Upsert")]
    public class UpsertAuthorizedEntitiesRequest : Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AuthenticationMethod> AuthenticationMethods { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }

        public class AuthenticationMethod
        {
            public string Id { get; set; }
            public string UID { get; set; }
            public string CardType { get; set; }
            public bool Enabled { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidUntil { get; set; }
        }
    }
}
