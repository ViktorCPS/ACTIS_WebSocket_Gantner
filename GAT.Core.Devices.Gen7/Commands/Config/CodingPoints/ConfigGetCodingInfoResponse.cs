namespace GAT.Core.Devices.Gen7.Commands.Config.CodingPoints
{
    //https://portal.gantner.com/display/0000000000GT7/21+Get+coding+info
    [CommandName("Config.GetCodingInfo")]
    public class ConfigGetCodingInfoResponse : Response
    {
        public int AvailablePoints { get; set; }
        public string Random { get; set; }
        public int TotalCoded { get; set; }
        public int TotalPoints { get; set; }
    }
}
