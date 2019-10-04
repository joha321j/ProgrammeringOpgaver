using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex73ThreadsIIExercise4
{
    class Transporter
    {
        private readonly int _bagQuota;
        private bool _jobsDone;
        private readonly Buffer _buffer;
        private readonly Random _randomGenerator = new Random((int)DateTime.Now.Ticks);

        public Transporter(Buffer buffer, int bagQuota)
        {
            _buffer = buffer;
            _bagQuota = bagQuota;
            _jobsDone = false;
        }

        public void Run()
        {
            while (!_jobsDone)
            {
                _buffer.Get(out _jobsDone, _bagQuota);
                Thread.Sleep(_randomGenerator.Next(12, 21) * 1000);
            }
        }
    }
}
