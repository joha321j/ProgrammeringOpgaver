using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareGris
{
    public delegate void SpareGrisEvent(object obj, EventArgs eventArgs);
    class Savings
    {
        public SpareGrisEvent SavingsEvent;

        private double _savings;

        public Savings(Screen screen)
        {
            SavingsEvent += screen.ShowSavings;
            _savings = 0;
        }

        public void InsertAmount(double amount)
        {
            _savings += amount;
            SavingsEvent?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return _savings.ToString();
        }
    }
}
