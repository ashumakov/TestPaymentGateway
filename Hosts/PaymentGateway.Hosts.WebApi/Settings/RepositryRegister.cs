using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Core.DataAccess.Context;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.DataAccessLayer.Implementation;

namespace PaymentGateway.Hosts.WebApi.Settings
{
    public static class RepositryRegister
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMerchantsRepository, MerchantsRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();

            services.AddDbContext<GatewayContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }
    }
}