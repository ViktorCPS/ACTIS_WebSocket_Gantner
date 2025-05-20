using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// Informs about a booking request of a person.
    /// </summary>
    /// <seealso cref="GAT.Core.Devices.Gen7.Gen7Event" />
    [CommandName("App.Balance")]
    public class BalanceEvent : Event
    {
        /// <summary>
        /// Gets or sets the used type of identification (<see cref="IdentificationType"/>).
        /// </summary>
        public int IdType { get; set; }

        /// <summary>
        /// Gets or sets the used value for identification.
        /// <list type="bullet">
        /// <item>IdType = 0: The data carrier UID as hex string (see Data.Card.UID). It is possible to configure the terminal so that instead a decimal value is returned.</item>
        /// <item>IdType = 1: The personal number of the user</item>
        /// <item>IdType = 1: The personal id of the user</item>
        /// </list>
        /// </summary>
        public string IdValue { get; set; }

        /// <summary>
        /// Gets or sets type of the IdValue. This is currently only used for IdType 0 and identifies the used data carrier type.
        /// </summary>
        public int IdValueType { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the identification.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the currently selected language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the RFID tag that was used for identification.
        /// </summary>
        public Card Card { get; set; }
    }
}