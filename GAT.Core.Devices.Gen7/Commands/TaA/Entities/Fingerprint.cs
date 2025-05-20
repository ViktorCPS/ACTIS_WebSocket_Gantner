namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single fingerprint of a person.
    /// </summary>
    public class Fingerprint
    {
        /// <summary>
        /// Gets or sets the Id of the person this fingerprint belongs to.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Gets or sets the number of the fingerprint (1-10).
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Gets or sets the fingerprint template data.
        /// </summary>
        public string Data { get; set; }
    }
}