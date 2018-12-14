using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class PumpDisplay : Display
    {
        private KeyValuePair<string, double> _amountFueled;
        private readonly GasPump _gasPump;
        public PumpDisplay(GasPump gasPump) : base(gasPump.GasStation)
        {
            _gasPump = gasPump;
            _gasPump.Attach(this);
        }

        public override void Update()
        {
            base.Update();
            _amountFueled = _gasPump.AmountFueled;
        }
        public void DisplayAmountFueled()
        {
            Console.WriteLine("You have fueled {0} L for a total price of {1} kr.", _amountFueled, Price(_amountFueled));
        }

        private double Price(KeyValuePair<string, double> amountFueled)
        {
            switch (amountFueled.Key)
            {
                case "AlcoOxygen":
                    return amountFueled.Value * AlcoOxygenPrice;
                case "HydroOxygen":
                    return amountFueled.Value * HydroOxygenPrice;
                case "KeroOxygen":
                    return amountFueled.Value * KeroOxygenPrice;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
