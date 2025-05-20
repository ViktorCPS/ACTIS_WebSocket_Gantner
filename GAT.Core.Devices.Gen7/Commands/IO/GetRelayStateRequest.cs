namespace GAT.Core.Devices.Gen7.Commands.IO
{
    [CommandName("IO.GetRelayState")]
    public class GetRelayStateRequest : Request
    {
        public int Id { get; set; }
    }
}
