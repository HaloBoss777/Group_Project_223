using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class BookingEntityConfiguration : EntityCongurationMapper<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(c => c.Booking_Id);

            builder.HasOne(x => x.Client).WithMany(d => d.Bookings).HasForeignKey(e => e.Client_Id).HasPrincipalKey(g => g.Client_Id);

            //builder.HasOne(x => x.Payment).WithMany(d => d.Bookings).HasForeignKey(e=>e.Payment_Id).HasPrincipalKey(g=>g.Booking_Id);

            builder.HasOne(x => x.Employee).WithMany(d => d.Bookings).HasForeignKey(e => e.Emp_Id).HasPrincipalKey(g => g.Emp_Id);

            builder.HasOne(x => x.Activity).WithMany(d => d.Bookings).HasForeignKey(e => e.Activity_Id).HasPrincipalKey(g => g.Activity_Id);


            builder.ToTable("Booking");
        }
    }
}
