using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareGris
{
    class Screen
    {
        private double _ticketPrice;

        public Screen(double ticketPrice)
        {
            _ticketPrice = ticketPrice;
        }
        public void ShowSavings(object obj, EventArgs eventargs)
        {
            Console.WriteLine("Your savings amount to a total of {0}.", obj);

            int ticketAmount =(int) (double.Parse(obj.ToString()) / _ticketPrice);

            if (ticketAmount > 0)
            {
                Console.WriteLine("Tillykke, du har nu penge nok til {0} sæsonkort til OBs kampe.", ticketAmount);
            }
        }
    }
}
