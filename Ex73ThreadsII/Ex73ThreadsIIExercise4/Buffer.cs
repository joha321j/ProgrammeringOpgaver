using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex73ThreadsIIExercise4
{
    class Buffer
    {
        private Buffer _buffer;
        private Queue<CandyBag> _bufferBags = new Queue<CandyBag>(18);
        private readonly object _lockObject = new object();
        private int amountOfCandyBagsRemoved;

        private Buffer()
        {
        }

        public Buffer GetBuffer()
        {
            if (_buffer == null)
            {
                lock (_lockObject)
                {
                    if (_buffer == null)
                    {
                        _buffer = new Buffer();
                    }
                }
            }

            return _buffer;
        }
        public void Put(CandyBag candyBag)
        {
            while (IsFull())
            {
                Monitor.Wait(_lockObject);
            }

            lock (_lockObject)
            {
                _bufferBags.Enqueue(candyBag);
                Monitor.PulseAll(_lockObject);
            }
        }

        public CandyBag Get(out bool jobsDone, int quota)
        {
            while (IsEmpty())
                Monitor.Wait(_lockObject);

            lock (_lockObject)
            {
                CandyBag candyBag = _bufferBags.Dequeue();
                Monitor.PulseAll(_lockObject);
                amountOfCandyBagsRemoved++;
                jobsDone = quota >= amountOfCandyBagsRemoved;
                return candyBag;
            }
        }

        private bool IsEmpty()
        {
            try
            {
                Monitor.Enter(_lockObject);

                return _bufferBags.Count == 0;
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

        private bool IsFull()
        {
            try
            {
                Monitor.Enter(_lockObject);

                return _bufferBags.Count == 18;
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

    }
}
