namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("Addon.GetConnectedLocks")]
    public class GetConnectedLocksRequest : Request
    {
        public string ControllerId { get; set; }
    }
}
