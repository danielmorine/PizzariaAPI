using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infra.Data.EntitiesConfiguration
{
    public class ClientAddressConfiguration : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Address)
                .HasColumnType("VARCHAR(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.Number)
                .HasColumnName("VARCHAR(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(b => b.City)
                .HasColumnName("VACHAR(300)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(b => b.ZipCode)
                .HasColumnName("VARCHAR(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(b => b.CreatedDate).IsRequired();
        }
    }
}
