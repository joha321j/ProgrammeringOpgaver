using System;

namespace Ex28.Domain
{
    internal class DatabaseException : Exception
    {
        public DatabaseException(string exceptionString) : base("Shit is fucked" + exceptionString)
        {

        }
    }
}
