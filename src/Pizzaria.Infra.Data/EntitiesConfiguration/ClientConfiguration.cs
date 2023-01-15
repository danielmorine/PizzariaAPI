using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infra.Data.EntitiesConfiguration;

public class Clientfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .HasColumnType("VARCHAR(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(b => b.ClientAddress)
            .WithOne(b => b.Client)
            .HasForeignKey<Client>(b => b.ClientAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.ClientPhone)
            .WithOne(b => b.Client)
            .HasForeignKey<Client>(b => b.ClientPhoneId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(b => b.CreatedDate).IsRequired();
    }
}
