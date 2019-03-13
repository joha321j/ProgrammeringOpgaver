using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {

            Recursion.TowersOfHanoi();
            Console.ReadKey();

            int faculty = Recursion.Faculty(5);
            Console.WriteLine("Fakultet af 5:");
            Console.WriteLine("{0}", faculty);
            Console.ReadKey();

            int fibonacci = Recursion.Fibonacci(5);
            Console.WriteLine("Det 4. Fibonacci tal:");
            Console.WriteLine("{0}", fibonacci);
            Console.ReadKey();

            bool palinddrome = Recursion.IsPalindrome("spansk snaps");
            Console.WriteLine("Er spanks snaps et palindrom?");
            Console.WriteLine("{0}", palinddrome);
            Console.ReadKey();



        }
    }
}
