using GAT.Core.Devices.Gen7.Commands.TaA.Entities;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to show the balances of a user. Normally after a <see cref="BalanceEvent"/> was handled unsuccessfully.
    /// </summary>
    [CommandName("App.StartBalancesProcess")]
    public class StartBalancesProcessRequest : Request
    {
        /// <summary>
        /// Gets or sets the text message to show to the user.
        /// </summary>
        public string DisplayText { get; set; } = "Your balances";

        /// <summary>
        /// Gets or sets an optional custom timeout for the message in ms.
        /// </summary>
        public int Timeout_ms { get; set; }

        /// <summary>
        /// Gets or sets an optional name of a custom icon to show to the user.
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// Gets or sets the balances of the person.
        /// </summary>
        public List<Balance> Balances { get; set; } = new List<Balance>();
    }
}