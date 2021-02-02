using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Services.Contracts;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.Implementation;

namespace PaymentGateway.Hosts.WebApi.Settings
{
    public static class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAcquiringBankService, TestBankService>();
        }
    }
}