using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Retrieves the details by PaymentId
    /// </summary>
    public class RetrievePaymentRequest : BaseRequest
    {
        /// <summary>
        /// PaymentId
        /// </summary>
        [Required]
        public string PaymentId { get; set; }
    }
}