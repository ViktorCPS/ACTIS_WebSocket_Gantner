namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request to delete a single or all persons from the terminal.
    /// </summary>
    [CommandName("App.DeletePerson")]
    public class DeletePersonRequest : Request
    {
        /// <summary>
        /// Gets or sets the unique Id of the person to delete. Ignored if ClearAll = true.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets whether to delete all existing persons from the device.
        /// </summary>
        public bool ClearAll { get; set; }
    }
}