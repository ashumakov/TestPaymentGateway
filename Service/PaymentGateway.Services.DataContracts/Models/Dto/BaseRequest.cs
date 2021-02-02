using System;

namespace PaymentGateway.Services.DataContracts.Models
{
    public class BaseRequest
    {
        public Guid MerchantId { get; set; }
    }
}