using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class EquipmentEntityConfiguration : EntityCongurationMapper<Equipment>
    {
        public override void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(c => c.Equipment_Id);
			builder.ToTable("Equipment");
        }
    }
}
