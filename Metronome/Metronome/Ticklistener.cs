using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metronome
{
    class TickListener
    {
        public TickListener(Metronome metronome)
        {
            metronome.MyMetronomeTick += TickTock;
        }

        private void TickTock()
        {
            Console.WriteLine("Heard you.");
        }
    }
}
