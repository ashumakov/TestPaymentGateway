using System;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface IAuthenticationService
    {
        bool AuthenticateMerchant(Guid merchantId, string signature, string requestBody);
    }
}