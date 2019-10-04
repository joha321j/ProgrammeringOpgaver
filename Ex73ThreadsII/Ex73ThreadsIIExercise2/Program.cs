using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex73ThreadsIIExercise2
{
    class Program
    {
        private const int Iterations = 1000000;
        private Int64 _number;

        public Int64 Number
        {
            get => _number;
            set => _number = value;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            Number = 0;
            Thread adder = new Thread(Add);
            Thread subtractor = new Thread(Subtract);
            adder.Start();
            subtractor.Start();
            adder.Join();
            subtractor.Join();
            Console.Write($"Number: {Number}. \t\tPress any key...");
            Console.ReadKey();
        }

        private void Add()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Interlocked.Increment(ref _number);
            }
        }

        private void Subtract()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Interlocked.Decrement(ref _number);
            }
        }
    }
}
