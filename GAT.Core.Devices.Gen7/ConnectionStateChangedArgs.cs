namespace GAT.Core.Devices.Gen7
{
    public class ConnectionStateChangedArgs
    {
        public bool IsConnected { get; set; }

        /// <summary>
        /// True if lost connection and reconnected or false for stoped and started manually
        /// </summary>
        public bool HasLostConnection { get; set; }
    }
}
