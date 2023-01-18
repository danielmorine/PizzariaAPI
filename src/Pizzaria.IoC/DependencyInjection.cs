using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenTelemetryElasticConnector;
using Pizzaria.Application.Mappings;
using Pizzaria.Application.Services;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Account.Interfaces;
using Pizzaria.Domain.Interfaces;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Identity;
using Pizzaria.Infra.Data.Repositories;
using Pizzaria.Infra.Data.Utils;
using System.Text;

namespace Pizzaria.IoC;

public static class DependencyInjection
{
    public static IServiceCollection InstallServiceInjection(this IServiceCollection services, IConfiguration configuration)
    {        
        services
            .AddSwaggerOptions()
            .AddInfrastructure(configuration)
            .AddAuthConfiguration(configuration)
            .AddTelemetry();
        return services;
    }

    public static IServiceCollection AddSwaggerOptions(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Email, senha e boa sorte"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
                }
            });
        });
        return services;
    }

    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = new JwtOptions(
          configuration["Jwt:SecretKey"],
          configuration["Jwt:Issuer"],
          configuration["Jwt:Audience"]);

        services.AddSingleton(jwtOptions);
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        return services;
    }

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
        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(typeof(AutoMapperProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("Pizzaria.Application");

        services.AddMediatR(myHandlers);
        return services;
    }

    public static IApplicationBuilder ConfigureCollectorElasticSearchServer(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.ConfigureApmServer(configuration);
        //app.UseMiddleware<MiddlewareForLogTelemetry>();

        return app;
    }
}
