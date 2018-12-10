using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class MainOffice : Subject
    {
        private double _keroOxygenPrice;
        public double AlcoOxygenPrice => KeroOxygenPrice * 1.1;
        public double HydroOxygenPrice => KeroOxygenPrice * 0.9;
        public double KeroOxygenPrice
        {
            get => _keroOxygenPrice;
            private set
            {
                _keroOxygenPrice = value;
                Notify();
            }
        }

        public void ChangeGasPrice(double newPrice)
        {
            KeroOxygenPrice = newPrice;
        }
        public string Name { get; }
        public MainOffice(string name)
        {
            Name = name;
        }
    }
}
