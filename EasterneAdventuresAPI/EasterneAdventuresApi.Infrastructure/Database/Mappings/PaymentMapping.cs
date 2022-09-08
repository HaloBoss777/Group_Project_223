using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class PaymentEntityConfiguration : EntityCongurationMapper<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(c => c.Payment_Id);

            builder.HasOne(x=>x.Client).WithMany(d=>d.Payments).HasForeignKey(e=>e.Client_Id).HasPrincipalKey(g => g.Client_Id);

            //builder.HasMany(x=>x.Bookings).WithOne(d=>d.Payment).HasForeignKey(z=>z.Booking_Id);

            builder.ToTable("Payment");
        }
    }
}
