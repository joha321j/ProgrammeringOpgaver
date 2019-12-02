using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Extreme.Mathematics;

namespace PrimeFactorCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Calculate the prime factors for a number!");
                Console.WriteLine("Enter your number, enter 0 to end the program.");
                int tempInt = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                if (tempInt == 0)
                {
                    running = false;
                }
                else
                {
                    List<int> primeFactors = CalculatePrimeFactor(tempInt);
                    List<int> checkPrimeFactos = IntegerMath.Factorize(tempInt).ToList();

                    foreach (var prime in primeFactors)
                    {
                        Console.WriteLine(prime);
                    }

                    foreach (var prime in checkPrimeFactos)
                    {
                        Console.WriteLine(prime);
                    }
                }
                
            }
           
        }

        public static List<int> CalculatePrimeFactor(int n)
        {
            int p = 2;
            List<int> primeFactors = new List<int>();

            while (n >= p * p)
            {
                if (n % p == 0)
                {
                    primeFactors.Add(p);
                    n /= p;
                }
                else
                {
                    p++;
                }
            }

            primeFactors.Add(n);

            return primeFactors;

        }
    }
}
