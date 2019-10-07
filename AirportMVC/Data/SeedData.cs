using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AirportMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirportMVC.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new AirportMVCContext(serviceProvider.GetRequiredService<DbContextOptions<AirportMVCContext>>()))
            {
                if (context.Flight.Any())
                {
                    return;
                }

                context.Flight.AddRange(
                    new Flight
                    {
                        AircraftType = "Boing 777 Jet",
                        FromLocation = "Copenhagen",
                        ToLocation = "Amsterdam",
                        DepartureTime = new DateTime(2019, 4, 10, 12, 0,0),
                        ArrivalTime = new DateTime(2019, 4, 10, 15, 0,0),
                        AvailableSeats = 100
                    });

                context.Flight.AddRange(
                    new Flight
                    {
                        AircraftType = "Boing 777 Jet",
                        FromLocation = "Copenhagen",
                        ToLocation = "Amsterdam",
                        DepartureTime = new DateTime(2019, 5, 10, 12, 0, 0),
                        ArrivalTime = new DateTime(2019, 5, 10, 15, 0, 0),
                        AvailableSeats = 1
                    });

                context.Flight.AddRange(
                    new Flight
                    {
                        AircraftType = "Boing 777 Jet",
                        FromLocation = "Amsterdam",
                        ToLocation = "Copenhagen",
                        DepartureTime = new DateTime(2019, 4, 10, 17, 0, 0),
                        ArrivalTime = new DateTime(2019, 4, 10, 20, 0, 0),
                        AvailableSeats = 50
                    });

                context.Flight.AddRange(
                    new Flight
                    {
                        AircraftType = "Boing 777 Jet",
                        FromLocation = "Copenhagen",
                        ToLocation = "Amsterdam",
                        DepartureTime = new DateTime(2019, 5, 10, 12, 0, 0),
                        ArrivalTime = new DateTime(2019, 5, 10, 15, 0, 0),
                        AvailableSeats = 0
                    });

                context.SaveChanges();
            }
        }
    }
}
