using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ConcreteObserver : Observer
    {
        private ConcreteSubject _subject;
        public int State { get; set; }

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
            Update();
        }
        public sealed override void Update()
        {
            State = _subject.State;
        }
    }
}
