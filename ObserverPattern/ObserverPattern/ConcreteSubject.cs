using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ConcreteSubject : Subject
    {
        private int _state;
        public int State
        {
            get => _state;
            set
            {
                _state = value;
                Notify();
            }
        }
    }
}
