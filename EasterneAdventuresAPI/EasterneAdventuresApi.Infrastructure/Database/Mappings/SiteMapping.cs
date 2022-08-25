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
			builder.ToTable("Booking");
        }
    }
}
