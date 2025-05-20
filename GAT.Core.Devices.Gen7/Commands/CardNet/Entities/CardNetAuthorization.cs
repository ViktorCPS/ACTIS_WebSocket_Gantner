using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.CardNet.Entities
{
    public class CardNetAuthorization
    {
        #region Properties

        /// <summary>
        /// Data carrier uid as read from the device as hex string MSB first. The length of the string has to be a multiple of 2 ("01AB" not "1AB") 
        /// </summary>
        public string UID { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CardTypeId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValidFrom { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValidUntil { get; set; }

        public byte Key { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<GroupAuthorization> Groups { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DoorAuthorization> Doors { get; set; }

        #endregion Properties
    }
}
