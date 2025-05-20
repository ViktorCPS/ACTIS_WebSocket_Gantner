namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to delete a single or multiple fingerprints from the terminal.
    /// </summary>
    [CommandName("App.DeleteFingerprint")]
    public class DeleteFingerprintRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the person to delete fingerprints. Ignored if ClearAll = true.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the number of the fingerprint to delete. May be combined with PersonId to delete one specific fingerprint of a person. 
        /// If no PersonId is provided, all fingerprints with this number will be deleted. Ignored if ClearAll = true.
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Gets or sets whether to delete all existing fingerprints from the device.
        /// </summary>
        public bool ClearAll { get; set; }
    }
}