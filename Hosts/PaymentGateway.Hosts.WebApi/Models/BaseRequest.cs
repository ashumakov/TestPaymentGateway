using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Base request that contains security verification data
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// Registered Merchant's ID
        /// </summary>
        [Required]
        public Guid MerchantId { get; set; }
    }
}