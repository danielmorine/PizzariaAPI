using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .HasColumnType("VARCHAR(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.CreatedDate).IsRequired();
    }
}
