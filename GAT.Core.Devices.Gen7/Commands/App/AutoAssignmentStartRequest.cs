using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Request to start autoassignment for g7 central
    /// https://portal.gantner.com/display/0000000000GT7/05.01.08.02+App.Locks.AutoAssignment.Start
    /// </summary>
    [CommandName("App.Locks.AutoAssignment.Start")]
    public class AutoAssignmentStartRequest : Request
    {
        #region Properties
        /// <summary>
        /// Gets or sets the carduid for the assignment
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigurationCardUID { get; set; }
        /// <summary>
        /// Gets or sets teh group id
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int GroupId { get; set; }
        /// <summary>
        /// Gets or sets the assignment start number
        /// </summary>
        public int StartNumber { get; set; }
        /// <summary>
        /// Gets or sets the step width for the locker number
        /// </summary>
        public int StepWidth { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Postfix { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfDigits { get; set; }

        #endregion Properties
    }
}
