using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate double BonusProvider(double amount);
    public static class Bonus
    {
        public static double TenPercent(double p0)
        {
            return p0 * 0.1;
        }

        public static double FlatTwoIfAmountMoreThanFive(double p0)
        {
            return p0 < 5 ? 0.0 : 2.0;
        }
    }
}
