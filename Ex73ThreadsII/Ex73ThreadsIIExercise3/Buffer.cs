using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex73ThreadsIIExercise3
{
    class Buffer
    {
        private readonly Queue<Car> _bufferData;
        private readonly int _capacity;
        private readonly object _bufferLock = new object();

        public Buffer(int capacity)
        {
            _capacity = capacity;
            _bufferData = new Queue<Car>();
        }
        public void Put(Car car)
        {
            while (IsFull())
            {
                Thread.Sleep(10);
            }
            try
            {
                Monitor.TryEnter(_bufferLock);

                _bufferData.Enqueue(car);
                if (_bufferData.Count > _capacity) throw new ArgumentException("Køen er fuld");
            }
            finally
            {
                Monitor.Exit(_bufferLock);
            }
        }
        public Car Get()
        {

            while (IsEmpty())
            {
                Thread.Sleep(10);
            }

            try
            {
                Monitor.TryEnter(_bufferLock);
                Car car = _bufferData?.Dequeue();

                return car;
            }
            finally
            {
                Monitor.Exit(_bufferLock);
            }
        }

        public bool IsEmpty()
        {
            bool empty;
            lock (_bufferLock)
            {
                empty = _bufferData.Count == 0;
            }
            return empty;
        }

        public bool IsFull()
        {
            bool full;
            lock (_bufferLock)
            {
                full = _bufferData.Count == _capacity;
            }
            return full;
        }
    }
}
