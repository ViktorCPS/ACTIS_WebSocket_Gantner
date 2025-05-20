namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("UnregisterEvent")]
    public class UnregisterEventRequest : Request
    {
        public string Event { get; set; }
    }
}
