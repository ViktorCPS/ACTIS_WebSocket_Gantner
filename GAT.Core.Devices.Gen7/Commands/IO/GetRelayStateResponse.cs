namespace GAT.Core.Devices.Gen7.Commands.IO
{
    [CommandName("IO.GetRelayState")]
    public class GetRelayStateResponse : Response
    {
        public int Id { get; set; }
        public bool State { get; set; }
    }
}
