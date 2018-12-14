using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    class Academy : Organization, IAcademy
    {
        private NotifyHandler _studentNotifier;

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                Notify();
            }
        }

        public Academy(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void Attach(IStudent student)
        {
            _studentNotifier += student.Update;
        }

        public void Detach(IStudent student)
        {
            _studentNotifier -= student.Update;
        }

        public void Notify()
        {
            _studentNotifier();
        }
    }
}
