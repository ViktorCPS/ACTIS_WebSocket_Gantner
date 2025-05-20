using System;
using System.Collections.Generic;
using System.Text;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    /// <summary>
    /// MFA credentials
    /// </summary>
    public class AuthorizationMfa
    {

        #region Properties

        /// <summary>
        /// Gets or sets if the user can handle lockers without pin
        /// </summary>
        public bool NoPinRequired { get; set; }

        /// <summary>
        /// Gets or sets the pin code
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets the card uid
        /// </summary>
        public string UID { get; set; }

        #endregion Properties
    }
}
