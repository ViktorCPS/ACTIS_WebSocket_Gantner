using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single person including their fingerprints and data carriers stored in the terminal.
    /// </summary>
    public class ExtendedPerson : Person
    {
        /// <summary>
        /// Gets or sets the data carriers of the person.
        /// </summary>
        public List<DataCarrier> DataCarriers { get; set; }

        /// <summary>
        /// Gets or sets the fingerprints of the person.
        /// </summary>
        public List<Fingerprint> FiuTemplates { get; set; }
    }
}