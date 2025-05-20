using System;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    [CommandName("GetDeviceInfo")]
    public class GetDeviceInfoResponse : Response
    {

        #region Properties

        public ActiveAppInfo ActiveApp { get; set; }
        public string ArticleNumber { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceName { get; set; }
        public int DeviceTypeId { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public IOInfo IO { get; set; }
        public LicenseInfo License { get; set; }
        public NetworkInfo Network { get; set; }
        public NetworkInfo Wlan { get; set; }
        public string SerialNumber { get; set; }

        #endregion Properties

        #region Classes

        public class ActiveAppInfo
        {

            #region Properties

            public string Author { get; set; }
            public DateTime Date { get; set; }
            public string DisplayName { get; set; }
            public DateTime LastChangedAt { get; set; }
            public int Level { get; set; }
            public string Name { get; set; }
            public PluginInfo Plugin { get; set; }
            public string Version { get; set; }

            #endregion Properties

            #region Classes

            public class PluginInfo
            {
                #region Properties

                public string Author { get; set; }
                public DateTime Date { get; set; }
                public string DisplayName { get; set; }
                public string Version { get; set; }

                #endregion Properties
            }

            #endregion Classes

        }
        public class IOInfo
        {
            #region Properties

            /// <summary>
            /// Number of available optocouplers and inputs
            /// </summary>
            public int NumberOptos { get; set; }
            /// <summary>
            /// Number of available relays
            /// </summary>
            public int NumberRelays { get; set; }

            #endregion Properties
        }

        public class LicenseInfo
        {

            #region Properties

            public int Level { get; set; }
            public bool OpenCard { get; set; }

            #endregion Properties

        }

        public class NetworkInfo
        {

            #region Properties

            public string Ip { get; set; }
            public string MAC { get; set; }

            #endregion Properties

        }

        #endregion Classes
    }
}
