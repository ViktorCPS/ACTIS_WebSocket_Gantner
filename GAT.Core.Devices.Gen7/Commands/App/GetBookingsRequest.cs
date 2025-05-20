using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using System;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.Bookings.Get")]
    public class GetBookingsRequest : Request
    {
        /// <summary>
        ///  Gets or sets the filter for online/offline bookings. if value is null both will be returned in the response.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Online { get; set; }
        /// <summary>
        /// Gets or sets the filter to get only bookings for a specific lock
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Lock Lock { get; set; } = null;

        /// <summary>
        /// Gets or sets the date filter
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? SinceUtc { get; set; }

        /// <summary>
        /// Gets or sets the Id filter. Only bookings greater than the specified value will be returned in the response.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long? SinceId { get; set; }

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long PageSize { get; set; }

    }
}
