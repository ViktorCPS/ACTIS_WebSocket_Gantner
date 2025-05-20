namespace GAT.Core.Devices.Gen7
{
    public class CommunicationEventArgs
    {
        public enum Directions
        {
            Incoming,
            Outgoing
        }
        public Directions Direction { get; set; }
        public string Data { get; set; }
    }
}
