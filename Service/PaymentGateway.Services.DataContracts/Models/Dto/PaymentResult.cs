namespace PaymentGateway.Services.DataContracts.Models
{
    public class PaymentResult
    {
        public string PaymentId { get; set; }
        public string MerchantId { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public BankInfo BankResponse { get; set; }
        public OrderDetails Order { get; set; }
        public AmountItem Amount { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
    }
}
