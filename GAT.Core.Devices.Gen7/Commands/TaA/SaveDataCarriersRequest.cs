using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to store one or multiple data carriers on the terminal (eg. for offline operation).
    /// </summary>
    [CommandName("App.SaveDataCarriers")]
    public class SaveDataCarriersRequest : Request
    {
        /// <summary>
        /// Gets or sets whether to clear all existing data carriers before inserting the new ones.
        /// </summary>
        public bool Clear { get; set; }

        /// <summary>
        /// Gets or sets the data carriers to save to the device.
        /// </summary>
        public List<DataCarrier> DataCarriers { get; set; }
    }
}