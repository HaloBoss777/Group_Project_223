using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class ActivityEquipmentEntityConfiguration : EntityCongurationMapper<ActivityEquipment>
    {
        public override void Configure(EntityTypeBuilder<ActivityEquipment> builder)
        {
            builder.HasKey(c => c.ActivityEquipment_Id);

            builder.HasOne(x=>x.Activity).WithMany(d=>d.ActivityEquipments).HasForeignKey(e=>e.Activity_Id).HasPrincipalKey(g => g.Activity_Id);

            builder.HasOne(x=>x.Equipment).WithMany(d=>d.ActivityEquipments).HasForeignKey(e=>e.Equipment_Id).HasPrincipalKey(g => g.Equipment_Id);

            builder.ToTable("ActivityEquipment");
        }
    }
}
