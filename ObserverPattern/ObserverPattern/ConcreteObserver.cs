using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ConcreteObserver : IObserver
    {
        private readonly ConcreteSubject _subject;
        public int State { get; private set; }

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
            Update();
        }
        public void Update()
        {
            State = _subject.State;
        }
    }
}
