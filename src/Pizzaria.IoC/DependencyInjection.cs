using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repositories;
using System.Text;

namespace Pizzaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(GetConnectionString(configuration.GetConnectionString("DefaultConnection")),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IClientAddressRepository, ClientAddressRepository>();
            services.AddScoped<IClientPhoneRepository, ClientPhoneRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
                        
            return services;
        }

        private static string GetConnectionString(string value)
        {
            var connectionString = value;
            if (value.Contains('\\'))
            {
                using FileStream fs = File.Open(value, FileMode.Open);
                byte[] b = new byte[1024];
                UTF8Encoding temp = new(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    connectionString = temp.GetString(b);
                }
            }

            return connectionString;
        }
    }
}
