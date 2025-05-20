namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to delete a single or multiple data carriers from the terminal.
    /// </summary>
    [CommandName("App.DeleteDataCarrier")]
    public class DeleteDataCarrierRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the person to delete data carriers. Ignored if ClearAll = true.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Uid of the data carrier to delete. May be combined with PersonId to delete one specific data carrier of a person. 
        /// If no PersonId is provided, all data carriers with this Uid will be deleted. Ignored if ClearAll = true
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets whether to delete all existing data carriers from the device.
        /// </summary>
        public bool ClearAll { get; set; }
    }
}