using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// The terminal response to a <see cref="GetDataCarriersRequest"/>.
    /// </summary>
    [CommandName("App.GetDataCarriers")]
    public class GetDataCarriersResponse : Response
    {
        /// <summary>
        /// Gets or sets the total count of data carriers in this response.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the the found data carriers.
        /// </summary>
        public List<DataCarrier> DataCarriers { get; set; }
    }
}