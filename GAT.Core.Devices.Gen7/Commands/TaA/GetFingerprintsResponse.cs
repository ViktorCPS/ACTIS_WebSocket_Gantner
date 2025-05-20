using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="GetFingerprintsRequest"/>.
    /// </summary>
    [CommandName("App.GetFingerprints")]
    public class GetFingerprintsResponse : Response
    {
        /// <summary>
        /// Gets or sets the total count of fingerprints in this response.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the the found fingerprints.
        /// </summary>
        public List<Fingerprint> Fingerprints { get; set; }
    }
}