namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="SaveFingerprintsRequest"/>.
    /// </summary>
    [CommandName("App.SaveFingerprints")]
    public class SaveFingerprintsResponse : SavePersonsResponse
    {
        /// <summary>
        /// Gets or sets the remaining amount of persons that can be stored in the fingerprint reader database if identification with fingerprint is configured.
        /// </summary>
        public int FiuRemainingPersons { get; set; }
    }
}