using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28
{
    internal class DatabaseException : Exception
    {
        public DatabaseException(string exceptionString) : base("Shit is fucked")
        {

        }
    }
}
