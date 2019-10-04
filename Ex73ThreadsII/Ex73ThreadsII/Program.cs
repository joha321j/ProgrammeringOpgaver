using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex73ThreadsII
{
    class Program
    {
        private double _accum = 0.0;
        private const int WeatherStations = 100;
        private const int Measures = 1000;
        private const double Value = 1.0;
        private readonly object _lockingObject = new object();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            const double EXPECTED = WeatherStations * Measures * Value;
            for (int i = 0; i < 10; i++)
            {
                _accum = 0.0;
                double result = Measure();
                if (result != EXPECTED)
                {
                    Console.WriteLine("ERROR: " + (EXPECTED - result));
                }
            }
            Console.Write("Press a key ..."); Console.ReadKey();
        }

        private double Measure()
        {
            Thread[] threads = new Thread[WeatherStations];
            for (int i = 0; i < WeatherStations; i++)
            {
                threads[i] = new Thread(Sensor);
                threads[i].Start();
            }
            //Do not join until all threads are started
            for (int i = 0; i < WeatherStations; i++)
            {
                threads[i].Join();  
            }
            return _accum;
        }

        private void Sensor()
        {
            for (int i = 0; i < Measures; i++)
            {
                lock (_lockingObject)
                {
                    double temp = _accum;
                    //do some work 
                    //Thread.Sleep(1);
                    _accum = temp + Value;
                }

             }
        }
    }
}
