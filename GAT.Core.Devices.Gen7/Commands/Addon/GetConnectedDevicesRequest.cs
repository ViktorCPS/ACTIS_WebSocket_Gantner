namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("Addon.GetConnectedDevices")]
    public class GetConnectedDevicesRequest : Request
    {
        public bool AddLocks { get; set; } = true;
    }
}
