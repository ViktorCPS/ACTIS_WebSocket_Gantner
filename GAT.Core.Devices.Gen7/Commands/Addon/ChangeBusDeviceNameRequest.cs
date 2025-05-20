namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Change addonbus device name alias.
    /// </summary>
    [CommandName("Addon.ChangeDeviceName")]
    public class ChangeBusDeviceNameRequest : Request
    {
        public string Id { get; set; }
        public string NewName { get; set; }
    }
}
