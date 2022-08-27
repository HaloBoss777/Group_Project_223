using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasterneAdventuresApi.Infrastructure.Database.Mappings
{
    public class ClientEntityConfiguration : EntityCongurationMapper<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Client_Id);
			builder.ToTable("Client");
        }
    }
}
