using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public delegate void NotifyHandler();
    public abstract class Subject
    {
        private NotifyHandler notifySubjectsHandler;

        public void Attach(IObserver observer)
        {
            notifySubjectsHandler += observer.Update;
        }

        public void Detach(IObserver observer)
        {
            notifySubjectsHandler -= observer.Update;
        }

        public void Notify()
        {
            notifySubjectsHandler();
        }
    }
}
