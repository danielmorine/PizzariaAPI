
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infra.Data.EntitiesConfiguration
{
    public class ClientPhonefiguration : IEntityTypeConfiguration<ClientPhone>
    {
        public void Configure(EntityTypeBuilder<ClientPhone> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Number)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(b => b.RegionNumber)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(b => b.CreatedDate).IsRequired();
        }
    }
}
