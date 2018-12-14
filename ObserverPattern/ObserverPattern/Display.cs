using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Display : IObserver
    {
        private readonly GasStation _gasStation;

        public double AlcoOxygenPrice { get; private set; }
        public double HydroOxygenPrice { get; private set; }
        public double KeroOxygenPrice { get; private set; }

        public Display(GasStation gasStation)
        {
            _gasStation = gasStation;
            _gasStation.Attach(this);
        }
        public virtual void Update()
        {
            AlcoOxygenPrice = _gasStation.AlcoOxygenPrice;
            HydroOxygenPrice = _gasStation.HydroOxygenPrice;
            KeroOxygenPrice = _gasStation.KeroOxygenPrice;

            DisplayPrices();
        }

        public void DisplayPrices()
        {
            Console.WriteLine("Tankstationen i region {0} i {1} har priserne:", _gasStation.Region, _gasStation.City);
            Console.WriteLine("Alcooxygen koster {0}", AlcoOxygenPrice);
            Console.WriteLine("Hydrooxygen koster {0}", HydroOxygenPrice);
            Console.WriteLine("Kerooxygen koster {0}", KeroOxygenPrice);
        }
    }
}
