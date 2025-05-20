namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.ConfirmProcessResult")]
    public class ConfirmProcessResult : Event
    {
        /// <summary>
        /// Gets or sets a value indicating whether the confirm process was successful or not. Returns true if successful
        /// </summary>
        public bool Result { get; set; }
    }
}
