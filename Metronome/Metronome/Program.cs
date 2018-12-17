using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metronome
{
    class Program
    {
        static void Main(string[] args)
        {
            Metronome myMetronome = new Metronome();
            TickListener myTickListener = new TickListener(myMetronome);

            myMetronome.Tick();
            Console.ReadKey();
        }
    }
}
