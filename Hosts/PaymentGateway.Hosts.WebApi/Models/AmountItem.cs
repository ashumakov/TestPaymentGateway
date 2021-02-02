using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Information about currency and 
    /// </summary>
    public class AmountItem
    {
        /// <summary>
        /// Three-letter ISO currency code
        /// Supported currency USD, EUR, PLN
        /// </summary>
        [Required]
        [RegularExpression(@"^([Uu][Ss][Dd])|([Ee][Uu][Rr])|([Pp][Ll][Nn])$")]
        public string Currency { get; set; }

        /// <summary>
        /// Value in provided currency
        /// </summary>
        [Required]
        [Range(0,999999)]
        public double Value { get; set; }
    }
}