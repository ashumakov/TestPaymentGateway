using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Order details from merchant
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// List of order items. E.g. position in shopping list, shipping details 
        /// </summary>
        public OrderItem[] DisplayItems { get; set; }

        /// <summary>
        /// Total information
        /// </summary>
        public OrderItem Total { get; set; }
    }

    /// <summary>
    /// Order item
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Description
        /// </summary>
        [StringLength(150)]
        public string Label { get; set; }

        /// <summary>
        /// Amount to display in invoice
        /// </summary>
        public AmountItem Amount { get; set; }
    }
}