using System;
using System.Runtime.Serialization;

namespace BadCode.Exceptions
{
    [Serializable]
    internal class TournamentException : Exception
    {
        public TournamentException()
        {
        }

        public TournamentException(string message) : base(message)
        {
        }

        public TournamentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TournamentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}