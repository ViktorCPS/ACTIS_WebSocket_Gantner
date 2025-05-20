namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    /// <summary>
    /// Search for new devices on the addon bus.
    /// The enumeration takes several seconds.
    /// If a new device is found,
    /// the Addon.BusDevicesChanged and Addon.BusDevicesChangedV2 event is fired.
    /// </summary>
    [CommandName("Addon.StartBusEnumeration")]
    public class StartBusEnumerationRequest : Request
    {
    }
}
