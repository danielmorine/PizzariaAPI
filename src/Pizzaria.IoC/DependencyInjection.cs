using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Application.Mappings;
using Pizzaria.Application.Services;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Account.Interfaces;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Identity;
using Pizzaria.Infra.Data.Repositories;
using Pizzaria.Infra.Data.Utils;

namespace Pizzaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>            
                options.UseSqlServer(StringUtils.GetValueFromFile(configuration.GetConnectionString("DefaultConnection"))));

            services.AddScoped<IClientAddressRepository, ClientAddressRepository>();
            services.AddScoped<IClientPhoneRepository, ClientPhoneRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IProductIngredientRepository, ProductIngredientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IIngredientService, IngredientService>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Pizzaria.Application");

            services.AddMediatR(myHandlers);
            return services;
        }    
    }
}
