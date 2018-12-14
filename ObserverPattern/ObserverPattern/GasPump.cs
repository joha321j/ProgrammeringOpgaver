using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class GasPump : Subject, IObserver
    {
        private GasTerminal _gasTerminal;
        public double AlcoOxygenPrice { get; private set; }
        public double HydroOxygenPrice { get; private set; }
        public double KeroOxygenPrice { get; private set; }
        internal GasStation GasStation { get; }
        public int PumpNumber { get; }
        public KeyValuePair<string, double> AmountFueled { get; private set; }

        public GasPump(int pumpNumber, GasStation gasStation)
        {
            PumpNumber = pumpNumber;
            GasStation = gasStation;
            gasStation.Attach(this);
            _gasTerminal = gasStation.GasTerminal;
            _gasTerminal.Attach(this);
        }

        public void SetFuel(string fuelType, double amount)
        {
            AmountFueled = new KeyValuePair<string, double>(fuelType, amount);
        }

        public void Update()
        {
            AlcoOxygenPrice = GasStation.AlcoOxygenPrice;
            HydroOxygenPrice = GasStation.HydroOxygenPrice;
            KeroOxygenPrice = GasStation.KeroOxygenPrice;
        }
    }
}
