namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Delete addonbus device.
    /// Only not connected devices can be deleted.
    /// </summary>
    [CommandName("Addon.DeleteDevice")]
    public class DeleteBusDeviceRequest : Request
    {
        public string Id { get; set; }
    }
}
