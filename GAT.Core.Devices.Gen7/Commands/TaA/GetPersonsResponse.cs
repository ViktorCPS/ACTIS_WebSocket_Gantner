using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="GetPersonsRequest"/>.
    /// </summary>
    [CommandName("App.GetPersons")]
    public class GetPersonsResponse : Response
    {
        /// <summary>
        /// Gets or sets the total count of persons in this response.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the the found persons.
        /// </summary>
        public List<ExtendedPerson> Persons { get; set; }
    }
}