namespace GAT.Core.Devices.Gen7.Commands.Config.CodingPoints
{
    //https://portal.gantner.com/display/0000000000GT7/22+Add+Top-up+License
    [CommandName("Config.AddTopUpLicense")]
    public class ConfigAddTopUpLicenseRequest : Request
    {
        public string TopUpLicense { get; set; }
    }
}
