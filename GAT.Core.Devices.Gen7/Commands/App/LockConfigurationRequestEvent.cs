using System;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// Event for close unassigned locker 
    /// This is needed for auto assigment without card
    /// </summary>
    [CommandName("App.Locks.AutoAssignment.LockConfigurationRequest")]
    public class LockConfigurationRequestEvent : Event
    {

        #region Properties
        [Obsolete("this property is kept for backward compatibility", false)]
        public ObsoleteData Data
        {
            set
            {
                CardUid = value.CardUid;
                Id = value.Id;
            }
        }

        /// <summary>
        /// Gets or sets the CardId which closes the locker
        /// </summary>
        public string CardUid { get; set; }

        /// <summary>
        /// Gets or sets the Id of the locker
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Wrong format in old version of G7 Main app.
        /// </summary>
        #endregion Properties
        public class ObsoleteData
        {
            #region Properties

            /// <summary>
            /// Gets or sets the CardId which closes the locker
            /// </summary>
            public string CardUid { get; set; }

            /// <summary>
            /// Gets or sets the Id of the locker
            /// </summary>
            public string Id { get; set; }

            #endregion Properties
        }

    }
}
