using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    interface IAcademy
    {
        void Attach(IStudent student);

        void Detach(IStudent student);

        void Notify();
    }
}
