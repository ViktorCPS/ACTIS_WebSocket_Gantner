using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    public class Device
    {
        #region Enums

        public enum DeviceTypes
        {
            Unknown,
            SMART_CONTROLLER,
            NET_CONTROLLER,
            SR7300,
            IO_EXPANDER
        }

        #endregion Enums

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string BlVersion { get; set; }

        [JsonIgnore]
        public DeviceTypes DeviceType
        {
            get
            {
                DeviceTypes retVal = DeviceTypes.Unknown;

                Enum.TryParse(Type, out retVal);

                return retVal;
            }
            set
            {
                if (value == DeviceTypes.Unknown)
                {
                    Type = null;
                }
                else
                {
                    Type = value.ToString();
                }
            }
        }

        /// <summary>
        /// hardware version
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// firmware version
        /// </summary>
        public string FwVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string FwUpdate { get; set; }

        /// <summary>
        /// firmware version
        /// </summary>
        public string HardwareVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string HumanReadableName { get; set; }

        /// <summary>
        /// hardware version
        /// </summary>
        public string HwVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<Lock> Locks { get; set; }

        public string SerialNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Type { get; set; }

        public string UpdateState { get; set; }

        /// <summary>
        /// Indicates if device has a fingerprint reader installed
        /// </summary>
        public bool FiuReady { get; set; }

        /// <summary>
        /// The name of the device
        /// </summary>
        [JsonProperty("Device")]
        public string DeviceName { get; set; }

        /// <summary>
        /// If the connection from the addonbus device is secured
        /// </summary>
        public bool IsSecure { get; set; }

        /// <summary>
        /// License error occures:
        /// * GC7 Main Light: > 3 Subcontrollers
        /// * other Devices:  > 8 Subcontrollers
        /// This property is undefined if false to save bandwith
        /// </summary>
        public bool LicenseError { get; set; } = false;
        #endregion Properties
    }
}
