namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Result of payment operation
    /// </summary>
    public class PaymentResult
    {
        /// <summary>
        /// Payment id in gateway
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Owner of payment
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Card holder name
        /// </summary>
        public string CardHolderName { get; set; }

        /// <summary>
        /// Billing address provided in payment
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Shipping address provided in payment
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Information from acquiring bank
        /// </summary>
        public BankInfo BankResponse { get; set; }

        /// <summary>
        /// Order details saved from initial request 
        /// </summary>
        public OrderDetails Order { get; set; }

        /// <summary>
        /// Amount details saved from initial request
        /// </summary>
        public AmountItem Amount { get; set; }
    }
}
