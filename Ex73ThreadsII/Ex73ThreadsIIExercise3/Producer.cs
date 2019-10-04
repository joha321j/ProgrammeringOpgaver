using System;
using System.Threading;

namespace Ex73ThreadsIIExercise3
{
    class Producer
    {
        private readonly string _name;
        private bool _stop;
        private readonly Buffer _buffer;

        private readonly Random _randomGenerator = new Random((int)DateTime.Now.Ticks);
        private int _count;

        public Producer(string name, Buffer buffer)
        {
            _name = name;
            _buffer = buffer;
        }
        public void Run()
        {
            while (!_stop)
            {
                ++_count;
                Car car = new Car(_name, _count.ToString());
                Console.WriteLine("Produce:" + car);
                _buffer.Put(car);
                Thread.Sleep(_randomGenerator.Next(50, 1500));
            }
        }
        public void SignalStop()
        {
            _stop = true;
        }
    }
}
