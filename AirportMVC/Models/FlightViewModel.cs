using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportMVC.Models
{
    public class FlightViewModel
    {
        public List<Flight> Flights { get; set; }
        public string ToLocationSearchString { get; set; }
        public string FromLocationSearchString { get; set; }
    }
}
