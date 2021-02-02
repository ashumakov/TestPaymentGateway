using AutoMapper;
using PaymentGateway.Core.DataAccess.Models;
using PaymentGateway.Services.DataContracts.Models;
using PaymentGateway.Services.DataContracts.Models.BankDto;

namespace PaymentGateway.Services.Implementation.Util
{
    public static class ServiceAutoMapper
    {
        public static void UseServiceProfiles(this IMapperConfigurationExpression config)
        {

            config.CreateMap<Address, string>().ConvertUsing<SerializeJsonTypeConverter<Address>>();
            config.CreateMap<string, Address>().ConvertUsing<DeserializeJsonTypeConverter<Address>>();

            config.CreateMap<OrderDetails, string>().ConvertUsing<SerializeJsonTypeConverter<OrderDetails>>();
            config.CreateMap<string, OrderDetails>().ConvertUsing<DeserializeJsonTypeConverter<OrderDetails>>();

            config.CreateMap<AmountItem, string>().ConvertUsing<SerializeJsonTypeConverter<AmountItem>>();
            config.CreateMap<string, AmountItem>().ConvertUsing<DeserializeJsonTypeConverter<AmountItem>>();

            config.CreateMap<PaymentRequest, Payment>()
                .ForMember(p => p.BillingAddress, o => o.MapFrom(x => x.BillingAddress))
                .ForMember(p => p.ShippingAddress, o => o.MapFrom(x => x.ShippingAddress))
                .ForMember(p => p.Order, o => o.MapFrom(x => x.Order))
                .ForMember(p => p.CardHolderName, o => o.MapFrom(x => x.Card.CardHolderName))
                .ForMember(p => p.CardNumber, o => o.ConvertUsing(new CreditCardValueConverter(), x => x.Card.CardNumber))
                .ForMember(p => p.Amount, o => o.MapFrom(x => x.Amount));
            config.CreateMap<Payment, PaymentResult>()
                .ForMember(p => p.PaymentId, o => o.MapFrom(x => x.Id))
                .ForMember(p => p.MerchantId, o => o.MapFrom(x => x.Owner.Id))
                .ForMember(p => p.BillingAddress, o => o.MapFrom(x => x.BillingAddress))
                .ForMember(p => p.ShippingAddress, o => o.MapFrom(x => x.ShippingAddress))
                .ForMember(p => p.Order, o => o.MapFrom(x => x.Order))
                .ForMember(p => p.Amount, o => o.MapFrom(x => x.Amount))
                .ForMember(p => p.CardNumber, o => o.MapFrom(x => x.CardNumber))
                .ForMember(p => p.CardHolderName, o => o.MapFrom(x => x.CardHolderName))
                .ForMember(p => p.BankResponse, o => o.MapFrom(x => x));

            config.CreateMap<Payment, BankInfo>()
                .ForMember(b => b.AuthCode, o => o.MapFrom(x => x.BankAuthCode))
                .ForMember(b => b.Status, o => o.MapFrom(x => x.BankStatus))
                .ForMember(b => b.StatusCode, o => o.MapFrom(x => x.BankStatusCode))
                .ForMember(b => b.TansactionId, o => o.MapFrom(x => x.BankTansactionId));

            config.CreateMap<PaymentRequest, BankAccount>()
                .ForMember(b => b.AccountOwnerName, o => o.MapFrom(x => x.Card.CardHolderName))
                .ForMember(b => b.AccountNumber, o => o.MapFrom(x => x.Card.CardNumber))
                .ForMember(b => b.AccountSecurityCode, o => o.MapFrom(x => x.Card.CardSecurityCode))
                .ForMember(b => b.AccountExpirationDate, o => o.MapFrom(x => x.Card.ExpirationDate));
            
            config.CreateMap<Merchant, BankAccount>()
                .ForMember(b => b.AccountOwnerName, o => o.MapFrom(x => x.Name))
                .ForMember(b => b.AccountNumber, o => o.MapFrom(x => x.BankAccountNumber))
                .ForMember(b => b.AccountSecurityCode, o => o.Ignore())
                .ForMember(b => b.AccountExpirationDate, o => o.Ignore());

            config.CreateMap<BankResponse, Payment>()
                .ForMember(p => p.BankTansactionId, o => o.MapFrom(x => x.TransactionId))
                .ForMember(p => p.BankAuthCode, o => o.MapFrom(x => x.AuthCode))
                .ForMember(p => p.BankStatus, o => o.MapFrom(x => x.Status))
                .ForMember(p => p.BankStatusCode, o => o.MapFrom(x => x.StatusCode));
        }
    }
}