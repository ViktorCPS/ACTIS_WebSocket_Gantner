namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single data carrier of a person.
    /// </summary>
    public class DataCarrier
    {
        /// <summary>
        /// Gets or sets the Id of the person this data carrier belongs to.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Gets or sets the data carrier UID as hex string. MSB first.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the type of the data carrier.
        /// </summary>
        public int CardType { get; set; }
    }
}