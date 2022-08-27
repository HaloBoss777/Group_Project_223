using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class ActivityEntityConfiguration : EntityCongurationMapper<Activity>
    {
        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(c => c.Activity_Id);

            builder.ToTable("Activity");
        }
    }
}
