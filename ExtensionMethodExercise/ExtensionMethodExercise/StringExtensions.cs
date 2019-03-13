using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodExercise
{
    public static class StringExtensions
    {
        public static string Shift(this string stringToShift, int k)
        {
            return stringToShift.Substring(stringToShift.Length - k) +
                   stringToShift.Substring(0, stringToShift.Length - k);
        }
    }
}
