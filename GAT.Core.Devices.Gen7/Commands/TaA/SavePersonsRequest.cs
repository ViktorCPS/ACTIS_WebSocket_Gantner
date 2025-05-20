using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to store one or multiple persons on the terminal (eg. for offline operation).
    /// </summary>
    [CommandName("App.SavePersons")]
    public class SavePersonsRequest : Request
    {
        /// <summary>
        /// Gets or sets whether to clear all existing persons before inserting the new ones.
        /// </summary>
        public bool Clear { get; set; }

        /// <summary>
        /// Gets or sets the person to store on the terminal.
        /// </summary>
        public List<Person> Persons { get; set; }
    }
}