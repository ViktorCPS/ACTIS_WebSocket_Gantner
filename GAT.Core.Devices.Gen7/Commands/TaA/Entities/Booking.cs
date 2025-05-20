using System;

namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single offline booking of the Time And Attendance app.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets or sets the unique Id of the booking.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the terminal that created the booking.
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// Gets or sets the used type of identification (<see cref="IdentificationType"/>).
        /// </summary>
        public int IdType { get; set; }

        /// <summary>
        /// Gets or sets the used value for identification.
        /// <list type="bullet">
        /// <item>IdType = 0: The data carrier UID as hex string (see Data.Card.UID). It is possible to configure the terminal so that instead a decimal value is returned.</item>
        /// <item>IdType = 1: The personal number of the user</item>
        /// <item>IdType = 1: The personal id of the user</item>
        /// </list>
        /// </summary>
        public string IdValue { get; set; }

        /// <summary>
        /// Gets or sets type of the IdValue. This is currently only used for IdType 0 and identifies the used data carrier type.
        /// </summary>
        public int IdValueType { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the identification.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the selected booking code (eg. coming, leaving, pause, etc.).
        /// </summary>
        public string BookingCode { get; set; }

        /// <summary>
        /// Gets or sets the selected reason code when using function 'ComingWithReason' or 'LeavingWithReason'.
        /// </summary>
        public string ReasonCode { get; set; }

        /// <summary>
        /// Gets or sets the selected account code when using function 'ComingWithAccount'.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the fingerprint verification result (<see cref="FiuVerificationResult"/>).
        /// </summary>
        public int FiuInfo { get; set; }

        /// <summary>
        /// Gets or sets the fingerprint verification score (<see cref="FiuMatchingScore"/>).
        /// </summary>
        public int FiuScore { get; set; }

        /// <summary>
        /// Gets or sets the presence state of the person when the booking was saved.
        /// </summary>
        public int PresenceState { get; set; }

        /// <summary>
        /// Gets or sets the Id of the person that performed the booking - if available. 
        /// Depending on the configuration of the device anonymous bookings are possible.
        /// </summary>
        public string PersonalId { get; set; }

        /// <summary>
        /// Gets or sets the number of the person that performed the booking - if available. 
        /// Depending on the configuration of the device anonymous bookings are possible.
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Gets or sets the prebooking code.
        /// </summary>
        public int Prebooking { get; set; }
    }
}