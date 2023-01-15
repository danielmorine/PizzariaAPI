using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;
using Pizzaria.Infra.Data.Identity;

namespace Pizzaria.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<ClientPhone> ClientPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
