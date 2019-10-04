using System;
using System.Threading;

namespace Ex73ThreadsIIExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Run();
        }
        public void Run()
        {
            Console.WriteLine("Start");

            Buffer buffer = new Buffer(50);

            Producer producer1 = new Producer("Opel", buffer);
            Producer producer2 = new Producer("Audi", buffer);
            Consumer consumer1 = new Consumer("forhandler 1", buffer);
            Consumer consumer2 = new Consumer("forhandler 2", buffer);
            Consumer consumer3 = new Consumer("forhandler 3", buffer);

            Thread tp1 = new Thread(producer1.Run);
            Thread tp2 = new Thread(producer2.Run);
            Thread tc1 = new Thread(consumer1.Run);
            Thread tc2 = new Thread(consumer2.Run);
            Thread tc3 = new Thread(consumer3.Run);

            Console.WriteLine("\nEnter for consumer 1 start");
            Console.ReadLine();
            tc1.Start();

            Console.WriteLine("\nEnter for producer 1 start");
            Console.ReadLine();
            tp1.Start();

            Console.WriteLine("\nEnter for consumer 2 start");
            Console.ReadLine();
            tc2.Start();

            Console.WriteLine("\nEnter for producer 2 start");
            Console.ReadLine();
            tp2.Start();

            Console.WriteLine("\nEnter for consumer 3 start");
            Console.ReadLine();
            tc3.Start();

            Console.WriteLine("\nStop tråde");
            Console.ReadLine();

            producer1.SignalStop();
            producer2.SignalStop();
            consumer1.SignalStop();
            consumer2.SignalStop();
            consumer3.SignalStop();

            tp1.Join();
            tp2.Join();
            tc1.Join();
            tc2.Join();
            tc3.Join();
            Console.WriteLine("\nEnter for Exit");
            Console.ReadLine();
            Console.WriteLine("Exit");
        }
    }
}
