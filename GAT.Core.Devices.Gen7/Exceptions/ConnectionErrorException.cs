using System;

namespace GAT.Core.Devices.Gen7.Exceptions
{
    public class ConnectionErrorException : Exception
    {
        public ConnectionErrorException()
        {
        }

        public ConnectionErrorException(string message) : base(message)
        {
        }

        public ConnectionErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
