namespace GAT.Core.Devices.Gen7.Commands.TaA
{
    /// <summary>
    /// A request that may be used in order to personalize the contents of the App. If a user identifies while the welcome screen is visible, 
    /// a 'PersonIdent' event is sent to the host that does not include a booking code. The host may then use this command to change the language of the App.
    /// </summary>
    [CommandName("App.StartPersonalizeProcess")]
    public class StartPersonalizeProcessRequest : Request
    {
        /// <summary>
        /// Gets or sets the language to use with the App. The default language is restored after the subsequent action(s) are finished (eg. when the welcome screen is shown again).
        /// </summary>
        public string Language { get; set; }
    }
}