using System;

namespace GAT.Core.Devices.Gen7.Exceptions
{
    public class CouldNotSendCommandException : Exception
    {
        public CouldNotSendCommandException(string message) : base(message)
        {
        }

        public CouldNotSendCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
