namespace GAT.Core.Devices.Gen7.Commands.Config
{
    [CommandName("Config.SetPassword")]
    public class SetPasswordRequest : Request
    {
        /// <summary>
        /// the user to set the password for
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// the password to set
        /// </summary>
        public string Password { get; set; }

    }
}
