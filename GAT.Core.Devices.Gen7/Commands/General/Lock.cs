using GAT.Core.Devices.Gen7.CardSegments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;

namespace GAT.Core.Devices.Gen7.Commands.General
{
    public class Lock
    {
        /// <summary>
        /// Id of the Lock,
        ///Format: <8Digtit Controller Article Number>-<10Digtit Controller Serial Number>-<2 Digit Channel Number>
        /// Use <see cref="Channel"/>, <see cref="ControllerArticleNumber"/>  and <see cref="ControllerSerialNumber"/> to use the parsed values.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = null;
        /// <summary>
        /// (optional) Locker Number if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public uint? Number { get; set; } = null;
        /// <summary>
        /// (optional) Locker Group if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public uint? Group { get; set; } = null;
        /// <summary>
        /// Id of the locker group
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? LockerGroupRecordId { get; set; } = null;

        /// <summary>
        /// (optional) Name of the locker group inside host software if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LockerGroupName { get; set; } = null;

        /// <summary>
        /// (optional) Locker label if configured
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = null;
        /// <summary>
        /// (optional) Antenna value of the locker
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Matching { get; set; } = null;
        /// <summary>
        /// mode of this lock
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public LockerModes? Mode { get; set; } = null;
        /// <summary>
        /// true if the lock is connected
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsConnected { get; set; } = null;
        /// <summary>
        /// Locker status infos
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public LockerStatus Status { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HwVersion { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FwVersion { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FwUpdate { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ArticleNumber { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SerialNumber { get; set; } = null;

        /// <summary>
        /// Gets the extracted channel info from <see cref="Id"/>
        /// </summary>
        [JsonIgnore]
        public int Channel
        {
            get
            {
                int retVal = 0;

                try
                {
                    retVal = int.Parse(Id.Substring(8 + 1 + 10 + 1, 2));
                }
                catch
                {
                    retVal = -1;
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets the extracted ControllerSerialNumber info from <see cref="Id"/>
        /// </summary>
        [JsonIgnore]
        public string ControllerSerialNumber
        {
            get
            {
                string retVal = "";

                try
                {
                    retVal = Id.Substring(8 + 1, 10);
                }
                catch
                {
                    retVal = "";
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets the extracted ControllerArticleNumber info from <see cref="Id"/>
        /// </summary>
        [JsonIgnore]
        public string ControllerArticleNumber
        {
            get
            {
                string retVal = "";

                try
                {
                    retVal = Id.Substring(0, 8);
                }
                catch
                {
                    retVal = "";
                }

                return retVal;
            }
        }

        public enum LockerModes
        {
            FreeLocker,
            PersonalLocker,
            DynamicLocker
        }

        /// <summary>
        /// 
        /// </summary>
        public class LockerStatus
        {
            /// <summary>
            /// Locker Lock satus
            ///Open ... Lock open
            ///Closed ... Lock closed but not Locked
            ///Locked ... Lock Closed and Locked
            /// </summary>
            [JsonConverter(typeof(StringEnumConverter))]
            public LockStates LockStatus { get; set; }
            /// <summary>
            /// Alarm state active. true = alarmed
            /// </summary>
            public bool Alarm { get; set; }
            /// <summary>
            /// Maintenance mode active
            /// </summary>
            public bool Maintenance { get; set; }
            /// <summary>
            /// Lock Rented
            /// </summary>
            public bool Rented { get; set; }
            /// <summary>
            /// 	Lock enabled
            /// </summary>
            public bool Enabled { get; set; }
            /// <summary>
            /// A change request (open / close usw) is currently handled
            /// </summary>
            public bool PendingOperation { get; set; }

            /// <summary>
            /// Lock blocked
            /// </summary>
            public bool Blocked { get; set; }

            /// <summary>
            /// (optional) 
            /// Data carrier UID as hex string. MSB first.
            /// ISO 14443A: "04501BFA983C80"
            /// ISO 15693:  "E00510000A1C9C7D"
            /// </summary>
            public string UID { get; set; }
            /// <summary>
            /// (optional)
            /// Mastercard UID as hex string. Only set for MasterIdentLocked and MasterIdentUnlocked
            /// </summary>
            public string MasterUID { get; set; }
            /// <summary>
            /// (optional)
            /// Maintenance UID as hex string. Only set for MaintenanceIdentLocked and MaintenanceIdentUnlocked
            /// </summary>
            public string MaintenanceUID { get; set; }
            /// <summary>
            /// (optional)
            /// System UID as hex string. Only set for SystemIdentLocked and SystemIdentUnlocked
            /// </summary>
            public string SystemUID { get; set; }

            /// <summary>
            /// Indicates the last action that happened on this lock
            /// </summary>
            [JsonConverter(typeof(StringEnumConverter))]
            public LastActions? LastAction { get; set; }
            /// <summary>
            /// (optional) RF Standard of the assigned card
            /// </summary>
            [DefaultValue(RfStandards.UNKNOWN)]
            [JsonConverter(typeof(DefaultUnknownEnumConverter))]
            public RfStandards RFStandard { get; set; }

            /// <summary>
            /// Timestamp of last use
            /// </summary>
            public DateTime? LastUse { get; set; }

            public enum LastActions
            {
                Unknown,
                ManuallyLocked,
                HostCommandLocked,
                HostCommandUnlocked,
                UserIdentLocked,
                UserIdentUnlocked,
                MasterIdentLocked,
                MasterIdentUnlocked,
                MaintenanceIdentLocked,
                MaintenanceIdentUnlocked,
                SystemIdentLocked,
                SystemIdentUnlocked
            }

            /// <summary>
            /// Locker Lock satus
            ///Open ... Lock open
            ///Closed ... Lock closed but not Locked
            ///Locked ... Lock Closed and Locked
            /// </summary>
            public enum LockStates
            {
                Open,
                Closed,
                Locked
            }
        }
    }

}
