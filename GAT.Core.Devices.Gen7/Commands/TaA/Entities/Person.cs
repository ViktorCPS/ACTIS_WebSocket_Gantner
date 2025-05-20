using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single person stored in the terminal.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets a unique identifier of the person (may be use to update or delete the person later).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the personal number the person may use to identify with PIN.
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the language of the person (ISO 639-1: en, de, it, fr, ...).
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the configuration of how to use finger verification:
        /// <list type="bullet">
        /// <item>0 = Unused</item>
        /// <item>1 = From database (please send the templates of the person too in this case)</item>
        /// <item>2 = From card</item>
        /// </list>
        /// </summary>
        public bool FiuVerification { get; set; }

        /// <summary>
        /// Gets or sets the presence state of the person:
        /// <list type="bullet">
        /// <item>0 = Unused</item>
        /// <item>1 = Present</item>
        /// <item>2 = Absent</item>
        /// <item>3 = Paused</item>
        /// </list>
        /// </summary>
        public int PresenceState { get; set; }

        /// <summary>
        /// Gets or sets the balances of the person.
        /// </summary>
        public List<Balance> Balances { get; set; } = new List<Balance>();
    }
}