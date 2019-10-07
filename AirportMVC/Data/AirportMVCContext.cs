using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirportMVC.Models
{
    public class AirportMVCContext : DbContext
    {
        public AirportMVCContext (DbContextOptions<AirportMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AirportMVC.Models.Flight> Flight { get; set; }
    }
}
