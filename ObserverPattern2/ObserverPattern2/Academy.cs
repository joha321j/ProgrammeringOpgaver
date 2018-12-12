using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    class Academy : Organization, IAcademy
    {
        private readonly List<IStudent> _students = new List<IStudent>();

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
            _students.Add(student);
        }

        public void Detach(IStudent student)
        {
            _students.Remove(student);
        }

        public void Notify()
        {
            foreach (IStudent observer in _students)
            {
                observer.Update();
            }
        }
    }
}
