using GAT.Core.Devices.Gen7.Commands.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    /// <summary>
    /// 
    /// </summary>
    [CommandName("App.Bookings.Get")]
    public class GetBookingsResponse : Response
    {
        /// <summary>
        /// Gets or sets the last booking id. This id can be used to obtain only "new" boookings with the next GetBookingsRequest.
        /// </summary>
        public long LastId { get; set; }
        /// <summary>
        /// Gets or sets the bookings
        /// </summary>
        public Booking[] Bookings { get; set; }

        /// <summary>
        /// Gets or sets if there are more bookings available
        /// </summary>
        public bool MoreBookingsAvailable { get; set; }

        /// <summary>
        /// booking
        /// </summary>
        public partial class Booking
        {
            /// <summary>
            /// Gets or sets the booking id
            /// </summary>
            public long Id { get; set; }
            /// <summary>
            /// Gets or sets the timestamp of the booking
            /// </summary>
            public DateTime UTCTimestamp { get; set; }
            /// <summary>
            /// Gets or sets if the device was online or offline
            /// </summary>
            public bool Online { get; set; }
            /// <summary>
            /// Gets or sets the <see cref="BookingData"/>
            /// </summary>
            public BookingDataWrapper BookingData { get; set; }
            /// <summary>
            /// class to wrap the booking data type/data
            /// </summary>
            public class BookingDataWrapper
            {
                /// <summary>
                /// booking types
                /// </summary>
                public enum BookingTypes
                {
                    Unknown,
                    ///
                    /// A lock has changed to the alarm state
                    ///
                    LockBreakupAlarm,

                    ///
                    /// A lock had been configured (number and group are not 0 anymore)
                    ///
                    LockConfigured,

                    ///
                    /// A lock had been unconfigured (number and group are 0 now)
                    ///
                    LockUnconfigured,

                    ///
                    /// The state of a relay has changed
                    ///
                    RelayStateChanged,

                    ///
                    /// The state of an opto has changed
                    ///
                    OptoStateChanged,

                    ///
                    /// Devices/Apps host connection has changed
                    ///
                    ConnectionStateChanged,

                    ///
                    /// All connected locks are opened
                    ///
                    AllLocksUnlocked,

                    ///
                    /// A lock has been unlocked
                    ///
                    LockUnlocked,

                    ///
                    /// A lock has been closed
                    ///
                    LockLocked,

                    ///
                    /// A lock has been unlocked with a master card
                    ///
                    LockUnlockedWithMaster,

                    ///
                    /// A lock has been locked with a master card
                    ///
                    LockLockedWithMaster,

                    ///
                    /// Lock opening action completion failed
                    ///
                    LockUnlockedFailed,

                    ///
                    /// Lock locking action completion failed
                    ///
                    LockLockedFailed,

                    ///
                    /// If a lock has been opened (statechange close or locked to open)
                    ///
                    LockOpened,

                    ///
                    /// If a lock has been closed but not locked (statechange open to closed or locked)
                    ///
                    LockClosed,

                    // /////////////////////////////////////////////////////////////////////////////////////// New Bookings (don"t exist on older controllers) //////////////////////////////////////////////////////////////////
                    /// <summary>
                    /// 
                    /// </summary>
                    LockDisabled,
                    /// <summary>
                    /// 
                    /// </summary>
                    LockEnabled,
                    /// <summary>
                    /// 
                    /// </summary>
                    LockMaintenanceActivated,
                    /// <summary>
                    /// 
                    /// </summary>
                    LockMaintenanceDeactivated,
                    /// <summary>
                    /// 
                    /// </summary>
                    LockLockedWithMasterFailed,
                    /// <summary>
                    /// 
                    /// </summary>
                    LockUnlockedWithMasterFailed,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusDeviceConnectionLost,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusDeviceConnectionFound,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusNewDevice,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusDeletedDevice,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusLockConnected,
                    /// <summary>
                    /// 
                    /// </summary>
                    AddonBusLockDisconnected,
                    /// <summary>
                    /// Old version of <see cref="AllAlarmsQuit"/>
                    /// </summary>
                    AllAlarmsQuitted,
                    /// <summary>
                    /// All alarms quitted by optocopler
                    /// </summary>
                    AllAlarmsQuit
                }
                /// <summary>
                /// The type of the <see cref="data"/>
                /// </summary>
                [DefaultValue(BookingTypes.Unknown)]
                [JsonConverter(typeof(DefaultUnknownEnumConverter))]
                public BookingTypes Booking { get; set; }
                /// <summary>
                /// Gets or sets the data. To see which type to cast see <see cref="BookingType"/>
                /// </summary>
                public JObject Data { get; set; }


                public class LockBookingData
                {
                    public class CardData
                    {
                        public GAT.Core.Devices.Gen7.CardSegments.CardTypes MyProperty { get; set; }
                        public string UID { get; set; }
                        public AuthorizationLevels AuthorizationLevel { get; set; }

                        public enum AuthorizationLevels
                        {
                            MASTER,
                            NO_PRIVILEGE
                        }
                    }

                    public CardData Card { get; set; }

                    public Lock Lock { get; set; }

                    public List<string> LockIds { get; set; }
                }

            }
        }
    }
}
