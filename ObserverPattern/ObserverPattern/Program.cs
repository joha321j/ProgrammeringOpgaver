using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGasStation();
        }

        static void TestGasStation()
        {
            var office = new MainOffice("RocketFuel ApS");

            var gasStationSealand = new GasStation(Region.Sjælland, "Sorø", office);
            var gasStationFuen = new GasStation(Region.Fyn, "Odense", office);
            var gasStationJutland = new GasStation(Region.Jylland, "Aarhus", office);

            office.ChangeGasPrice(12.5);
            Console.ReadKey();

            office.Detach(gasStationSealand);
            office.ChangeGasPrice(10.0);

            Console.ReadKey();

            Console.WriteLine("Add discount");
            gasStationFuen.Discount = true;
            Console.ReadKey();

            Console.WriteLine("Remove discount");
            gasStationFuen.Discount = false;
            Console.ReadKey();
        }
        static void TestAcademy()
        {
            var p = new Academy("UCL");

            var s1 = new Student(p, "Jens");
            var s2 = new Student(p, "Niels");
            var s3 = new Student(p, "Susan");

            p.Attach(s1);
            p.Attach(s2);
            p.Attach(s3);

            p.Message = "Så er der julefrokost!";

            p.Detach(s2);

            p.Message = "Så er der fredagsbar!";

            Console.ReadKey();
        }
    }
}
