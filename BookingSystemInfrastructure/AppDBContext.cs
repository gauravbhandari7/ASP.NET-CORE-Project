using BookingSystemModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemInfrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options) : base(options)
        {

        }
        public DbSet<Flight> Flights { get; set; }
    }
}
