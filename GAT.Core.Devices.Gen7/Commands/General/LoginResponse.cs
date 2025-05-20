namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("Login")]
    public class LoginResponse : Response
    {
        public string AccessToken { get; set; }
        public string User { get; set; }
    }
}
