using System;

namespace GAT.Core.Devices.Gen7.Exceptions
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException()
        {
        }

        public RequestFailedException(string message) : base(message)
        {
        }

        public RequestFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public byte? State { get; set; }
        public new object Data { get; set; }
    }
}
