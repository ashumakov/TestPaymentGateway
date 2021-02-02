using System;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.Implementation.Util;

namespace PaymentGateway.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool AuthenticateMerchant(Guid merchantId, string signature, string requestBody)
        {
            var merchantInfo = _unitOfWork.Merchants.GetAsync(merchantId).Result;
            if (merchantInfo != null)
            {
                var signedRequest = HashHelper.CalculateSHA512Hash(
                    $"{merchantInfo.SigningKey}{requestBody}{merchantInfo.SigningKey}");

                return signedRequest == signature;
            }

            return false;
        }
    }
}