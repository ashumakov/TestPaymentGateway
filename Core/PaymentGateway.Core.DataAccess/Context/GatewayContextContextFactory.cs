using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PaymentGateway.Core.DataAccess.Context
{
    /// <summary>
    /// Class is used for command line migration apply
    /// </summary>
    public class GatewayContextContextFactory : IDesignTimeDbContextFactory<GatewayContext>
    {
        public GatewayContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GatewayContext>();
            optionsBuilder.UseSqlServer(GetConnectionString(args[0]));

            return new GatewayContext(optionsBuilder.Options);
        }

        public static string GetConnectionString(string configurationPath = "")
        {
            var builder = new ConfigurationBuilder().AddJsonFile(configurationPath);

            var configuration = builder.Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
