namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to get persons stored on the terminal.
    /// </summary>
    [CommandName("App.GetPersons")]
    public class GetPersonsRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the person to fetch. Leave empty to fetch all persons.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of persons to skip. Ignored if Id is not empty.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets the amount of persons to fetch. Ignored if Id is not empty.
        /// </summary>
        public int Count { get; set; }
    }
}