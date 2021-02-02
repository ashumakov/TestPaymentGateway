using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Hosts.WebApi.Models;
using PaymentGateway.Services.Implementation.Util;

namespace PaymentGateway.Hosts.WebApi.Settings
{
    public static class AutoMapperRegister
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = SetMapping();
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapperConfig);
            services.AddSingleton(mapper);
        }

        private static MapperConfiguration SetMapping()
        {
            return new MapperConfiguration(UseMapping);
        }

        private static void UseMapping(IMapperConfigurationExpression config)
        {
            #region Automapper 

            config.CreateMap<Address, Services.DataContracts.Models.Address>();
            config.CreateMap<Services.DataContracts.Models.Address, Address>();

            config.CreateMap<AmountItem, Services.DataContracts.Models.AmountItem>();
            config.CreateMap<Services.DataContracts.Models.AmountItem, AmountItem>();

            config.CreateMap<BankInfo, Services.DataContracts.Models.BankInfo>();
            config.CreateMap<Services.DataContracts.Models.BankInfo, BankInfo>();

            config.CreateMap<BaseRequest, Services.DataContracts.Models.BaseRequest>();

            config.CreateMap<CardPaymentInfo, Services.DataContracts.Models.CardPaymentInfo>();

            config.CreateMap<OrderItem, Services.DataContracts.Models.OrderItem>();
            config.CreateMap<Services.DataContracts.Models.OrderItem, OrderItem>();

            config.CreateMap<OrderDetails, Services.DataContracts.Models.OrderDetails>();
            config.CreateMap<Services.DataContracts.Models.OrderDetails, OrderDetails>();

            config.CreateMap<PaymentRequest, Services.DataContracts.Models.PaymentRequest>();
            config.CreateMap<RetrievePaymentRequest, Services.DataContracts.Models.RetrievePaymentRequest>();
            config.CreateMap<Services.DataContracts.Models.PaymentResult, PaymentResult>();

            #endregion

            config.UseServiceProfiles();
            
            config.ForAllMaps((obj, cfg) => cfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
        }
    }
}