using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repositories;

namespace Pizzaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IClientAddressRepository, ClientAddressRepository>();
            services.AddScoped<IClientPhoneRepository, ClientPhoneRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
                        
            return services;
        }
    }
}
