namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to get data carriers stored on the terminal.
    /// </summary>
    [CommandName("App.GetDataCarriers")]
    public class GetDataCarriersRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the person to get the records of. Empty to get all records.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Gets or sets the amount of records to skip. Ignored if PersonId is not empty.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets the amount of records to fetch. Ignored if PersonId is not empty.
        /// </summary>
        public int Count { get; set; }
    }
}