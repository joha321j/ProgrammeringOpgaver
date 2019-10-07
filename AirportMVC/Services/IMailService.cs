using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportMVC.Services
{
    public interface IMailService
    {
        void SendEmail(string emailAddress, string subject, string message);
    }
}
