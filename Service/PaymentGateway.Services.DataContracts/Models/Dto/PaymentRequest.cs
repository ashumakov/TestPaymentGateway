namespace PaymentGateway.Services.DataContracts.Models
{
    public class PaymentRequest : BaseRequest
    {
        public CardPaymentInfo Card { get; set; }
        public AmountItem Amount { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public OrderDetails Order { get; set; }
    }
}
