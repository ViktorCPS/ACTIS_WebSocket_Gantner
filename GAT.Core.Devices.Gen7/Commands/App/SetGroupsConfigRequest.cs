using System;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.Addon
{
    [CommandName("App.SetGroupsConfig")]
    public class SetGroupsConfigRequest : Request
    {
        #region Properties

        public List<GroupConfiguration> GroupConfig { get; set; }

        #endregion Properties

        #region Classes

        public class GroupConfiguration
        {
            #region Properties

            /// <summary>
            /// (optional) The name of the locker area
            /// </summary>
            public string Area { get; set; }

            /// <summary>
            /// Id of the Group,
            ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// The id of the locker group
            /// </summary>
            public Guid LockerGroupRecordId { get; set; }
            /// <summary>
            /// (optional) The text which will be shown on the central if no locker is available
            /// </summary>
            public string InfoText { get; set; }

            /// <summary>
            /// (optional) The name of the locker group
            /// </summary>
            public string Name { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }
}
