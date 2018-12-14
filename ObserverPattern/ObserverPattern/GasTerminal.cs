using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class GasTerminal : Subject, IObserver
    {
        public bool FuelPaid;

        public void Update()
        {
            if (FuelPaid)
            {
                Notify();
            }
        }

        public void Display()
        {

        }
    }
}
