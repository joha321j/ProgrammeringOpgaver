using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metronome
{
    public delegate void MetronomeTick();
    class Metronome
    {
        public event MetronomeTick MyMetronomeTick;
        public void Tick()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(3000);
                MyMetronomeTick.Invoke();
            }
        }

    }
}
