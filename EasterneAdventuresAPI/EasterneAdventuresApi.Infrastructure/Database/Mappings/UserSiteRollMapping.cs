using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class UserSiteRollEntityConfiguration : EntityCongurationMapper<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x=>x.User).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.UserId).HasPrincipalKey(g => g.Id);

            builder.HasOne(x=>x.Site).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.SiteId).HasPrincipalKey(g => g.Id);

            builder.HasOne(x=>x.Permission).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.PermissionId).HasPrincipalKey(g => g.Id);


            builder.ToTable("UserSiteRoll");
        }
    }
}
