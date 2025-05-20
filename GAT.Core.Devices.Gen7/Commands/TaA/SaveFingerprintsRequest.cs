using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to store one or multiple fingerprints on the terminal (eg. for offline operation verification or identification).
    /// </summary>
    [CommandName("App.SaveFingerprints")]
    public class SaveFingerprintsRequest : Request
    {
        /// <summary>
        /// Gets or sets whether to clear all existing fingerprints before inserting the new ones.
        /// </summary>
        public bool Clear { get; set; }

        /// <summary>
        /// Gets or sets whether to let the device handle unsupported finger template headers (first 3 bytes). Usually the client should take care of providing correct templates and this value should be false.
        /// </summary>
        public bool AutoAdjustFingerTemplates { get; set; }

        /// <summary>
        /// Gets or sets the fingerprints to save to the device.
        /// </summary>
        public List<Fingerprint> Fingerprints { get; set; }
    }
}