using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Application.Interfaces;
using Pizzaria.Application.Mappings;
using Pizzaria.Application.Services;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repositories;

namespace Pizzaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IClientAddressRepository, ClientAddressRepository>();
            services.AddScoped<IClientPhoneRepository, ClientPhoneRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IIngredientService, IngredientService>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Pizzaria.Application");

            services.AddMediatR(myHandlers);
            return services;
        }    
    }
}
