using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Pizzaria.Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(GetConnectionString(connectionString));

            return new ApplicationDbContext(builder.Options);
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
