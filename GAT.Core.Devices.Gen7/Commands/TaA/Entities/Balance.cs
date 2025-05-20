namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// A single balance of a person.
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// Gets or sets the name of the balance (eg. 'Overtime').
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the balance (eg. '12:30h').
        /// </summary>
        public string Value { get; set; }
    }
}