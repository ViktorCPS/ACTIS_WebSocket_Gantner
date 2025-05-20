using Newtonsoft.Json;
using System;

namespace GAT.Core.Devices.Gen7.Commands.CardNet.Entities
{
    public class CardNetBooking
    {
        #region Properties

        public int Id { get; set; }

        public int Code { get; set; }

        public int CardTypeId { get; set; }

        public DateTime Timestamp { get; set; }

        public DateTime? ValidUntil { get; set; }

        public string PersonalId { get;  set; }

        public string PersonalNumber { get; set; }

        [JsonProperty("DoorId")]
        public int? BatteryWarningDoorId { get; set; }

        [JsonProperty("Count")]
        public int? BatteryWarningCount { get; set; }

        [JsonProperty("Date")]
        public DateTime? BatteryWarningDate { get; set; }

        #endregion Properties
    }
}
