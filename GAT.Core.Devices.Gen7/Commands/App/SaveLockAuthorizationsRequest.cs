using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.SaveLockAuthorizations")]
    public class SaveLockAuthorizationsRequest : Request
    {

        /// <summary>
        /// the personal lock
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Lock Lock { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UIDSet> UIDSets { get; set; } = new List<UIDSet>();

        public class UIDSet
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> UIDs { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Barcodes { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? IdentPin { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? VerifyPin { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? ValidFrom { get; set; } = null;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? ValidTo { get; set; } = null;
        }
    }
}
