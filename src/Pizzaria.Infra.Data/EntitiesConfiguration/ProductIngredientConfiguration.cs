using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infra.Data.EntitiesConfiguration;

public class ProductIngredientConfiguration : IEntityTypeConfiguration<ProductIngredient>
{
    public void Configure(EntityTypeBuilder<ProductIngredient> builder)
    {
        builder.HasKey(b => b.Id);          
        builder.Property(b => b.CreatedDate).IsRequired();

        builder.HasOne(b => b.Product)
             .WithMany(b => b.ProductIngredients)
             .HasForeignKey(b => b.ProductId)
             .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Ingredient)
            .WithMany(b => b.ProductIngredients)
            .HasForeignKey(b => b.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
