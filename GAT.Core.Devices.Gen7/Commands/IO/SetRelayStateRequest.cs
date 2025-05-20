namespace GAT.Core.Devices.Gen7.Commands.IO
{
    [CommandName("IO.SetRelayState")]
    public class SetRelayStateRequest : Response
    {
        public int Id { get; set; }
        public bool State { get; set; }
    }
}
