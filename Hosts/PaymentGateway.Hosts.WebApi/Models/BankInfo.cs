using System;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Acquiring bank info
    /// </summary>
    public class BankInfo
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        public string TansactionId { get; set; }

        /// <summary>
        /// Authentication code
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public string StatusCode { get; set; }
    }
}