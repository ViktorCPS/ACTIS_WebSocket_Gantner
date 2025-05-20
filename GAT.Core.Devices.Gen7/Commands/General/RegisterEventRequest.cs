namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("RegisterEvent")]
    public class RegisterEventRequest : Request
    {
        public string Event { get; set; }
    }
}
