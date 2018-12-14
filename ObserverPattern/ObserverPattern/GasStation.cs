using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public enum Region
    {
        Sjælland = 105,
        Fyn = 95,
        Jylland = 100
    }

    public class GasStation :Subject, IObserver
    {
        private bool _discount;
        private readonly MainOffice _mainOffice;
        internal GasTerminal GasTerminal;

        public bool Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                Update();
            }
        }

        public double AlcoOxygenPrice { get; private set; }
        public double HydroOxygenPrice { get; private set; }
        public double KeroOxygenPrice { get; private set; }

        public string City { get; }
        public Region Region { get; }

        public GasStation(Region region, string city, MainOffice mainOffice)
        {
            Region = region;
            City = city;
            _mainOffice = mainOffice;
            mainOffice.Attach(this);
            GasTerminal = new GasTerminal();
            new Display(this);
        }

        public void Update()
        {
            if (_discount)
            {
                SetPrices(0.9);
            }
            else
            {
                SetPrices(1);
            }
            Notify();
        }

        private void SetPrices(double discount)
        {
            switch (Region)
            {
                case Region.Sjælland:
                    AlcoOxygenPrice = _mainOffice.AlcoOxygenPrice * ((double)Region.Sjælland / 100 )* discount;
                    HydroOxygenPrice = _mainOffice.HydroOxygenPrice * ((double)Region.Sjælland / 100) * discount;
                    KeroOxygenPrice = _mainOffice.KeroOxygenPrice * ((double)Region.Sjælland / 100 )* discount;
                    break;
                case Region.Fyn:
                    AlcoOxygenPrice = _mainOffice.AlcoOxygenPrice * ((double)Region.Fyn / 100) * discount;
                    HydroOxygenPrice = _mainOffice.HydroOxygenPrice * ((double)Region.Fyn / 100) * discount;
                    KeroOxygenPrice = _mainOffice.KeroOxygenPrice * ((double)Region.Fyn / 100) * discount;
                    break;
                case Region.Jylland:
                    AlcoOxygenPrice = _mainOffice.AlcoOxygenPrice * ((double)Region.Jylland / 100) * discount;
                    HydroOxygenPrice = _mainOffice.HydroOxygenPrice * ((double)Region.Jylland / 100) * discount;
                    KeroOxygenPrice = _mainOffice.KeroOxygenPrice * ((double)Region.Jylland / 100) * discount;
                    break;
            }
        }
    }
}
