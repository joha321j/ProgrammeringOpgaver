using System;
using System.Threading;

namespace Ex73ThreadsIIExercise3
{
    class Consumer
    {
        private readonly string _name;
        private bool _stop;
        private readonly Buffer _buffer;

        private readonly Random _randomGenerator = new Random((int)DateTime.Now.Ticks);

        public Consumer(string name, Buffer buffer)
        {
            _name = name;
            _buffer = buffer;
        }
        public void Run()
        {
            while (!_stop)
            {
                Console.WriteLine(_name + " Consume: ");
                Car car = _buffer.Get();      //hent Car
                Console.WriteLine(_name + " Resived: " + car);
                Thread.Sleep(_randomGenerator.Next(50, 1000));
            }
        }
        public void SignalStop()
        {
            _stop = true;
        }
    }
}
