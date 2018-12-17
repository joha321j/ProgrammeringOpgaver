using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareGris
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Screen screen = new Screen(595);
            Savings savings = new Savings(screen);
            bool running = true;
            while (running)
            {
                bool validParse = double.TryParse(Console.ReadLine(), out double userResult);
                if (!validParse)
                {
                    Console.WriteLine("Wrong input");
                }
                else
                {
                    if (Math.Abs(userResult) < 0.0001 && Math.Abs(userResult) > -0.000001)
                    {
                        running = false;
                    }
                    savings.InsertAmount(userResult);
                }

            }
        }
    }
}
