using GAT.Core.Devices.Gen7.Commands.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// Request to set mfa authentication for the given uid
    /// </summary>
    [CommandName("App.SetMfaPin")]
    public class SetMfaPinRequest : Request
    {
        #region Properties

        public List<AuthorizationMfa> MfaSets { get; set; } = new List<AuthorizationMfa>();

        #endregion Properties
    }
}
