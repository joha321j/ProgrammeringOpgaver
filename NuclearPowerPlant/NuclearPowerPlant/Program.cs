using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearPowerPlant
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen();
            Worker worker = new Worker(Worker.Status.Alive, "Kaare", screen);


            worker.SendStatus();
            Console.ReadKey();
        }
    }
}
