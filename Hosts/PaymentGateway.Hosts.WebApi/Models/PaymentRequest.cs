using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Payment information
    /// </summary>
    public class PaymentRequest : BaseRequest
    {
        /// <summary>
        /// Client credit card info
        /// </summary>
        [Required]
        public CardPaymentInfo Card { get; set; }

        /// <summary>
        /// Total amount to take from client card
        /// </summary>
        [Required]
        public AmountItem Amount { get; set; }

        
        /// <summary>
        /// Billing address. Optional parameter
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Shipping address. Optional parameter
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Order detail information. Could be used in invoice. Optional parameter
        /// </summary>
        public OrderDetails Order { get; set; }
    }
}
