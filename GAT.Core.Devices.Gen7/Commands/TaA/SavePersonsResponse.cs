using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="SavePersonsResponse"/>.
    /// </summary>
    [CommandName("App.SavePersons")]
    public class SavePersonsResponse : Response
    {
        /// <summary>
        /// Gets or sets the amount of records that were changed (updated or added).
        /// </summary>
        public int AffectedRecords { get; set; }

        /// <summary>
        /// Gets or sets an error message if one or more persons could not be saved to the database.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the Ids of the persons that could not be saved.
        /// </summary>
        public List<string> FailedPersons { get; set; }
    }
}