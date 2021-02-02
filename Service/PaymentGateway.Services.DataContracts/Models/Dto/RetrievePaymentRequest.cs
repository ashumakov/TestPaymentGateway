using System;

namespace PaymentGateway.Services.DataContracts.Models
{
    public class RetrievePaymentRequest : BaseRequest
    {
        public Guid PaymentId { get; set; }
    }
}