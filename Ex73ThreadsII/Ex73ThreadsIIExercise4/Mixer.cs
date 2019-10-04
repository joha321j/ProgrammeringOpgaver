using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex73ThreadsIIExercise4
{
    class Mixer
    {
        private readonly int _bagQuota;
        private readonly Buffer _buffer;
        private readonly Random _randomGenerator = new Random((int)DateTime.Now.Ticks);

        public Mixer(Buffer buffer)
        {
            _buffer = buffer;
            _bagQuota = 200;
        }

        public void Run()
        {
            for (int i = 0; i < _bagQuota; i++)
            {
                CandyBag tempBag = new CandyBag();
                _buffer.Put(tempBag);
                Thread.Sleep(_randomGenerator.Next(18, 31) * 1000);
            }
        }
    }
}
