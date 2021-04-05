using BookingSystemModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemInfrastructure.Configuration
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Airline).IsRequired();
        }
    }
}
