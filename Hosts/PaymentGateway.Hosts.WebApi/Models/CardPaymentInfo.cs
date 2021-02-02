using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Credit card info
    /// </summary>
    public class CardPaymentInfo : IValidatableObject
    {
        /// <summary>
        /// Card number
        /// Visa                4111111111111111
        /// MasterCard 	        5500000000000004
        /// American Express 	340000000000009
        /// Discover 	        6011000000000004
        /// JCB 	            3088000000000009
        /// </summary>
        [Required]
        [StringLength(maximumLength:16,  ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 13) ]
        [CreditCard]
        public string CardNumber { get; set; }

        /// <summary>
        /// Card Verification Value
        /// VISA, MasterCard, JCB and Discover is a 3 digit number  123
        /// American Express is a 4 digit numeric code              1234
        /// </summary>
        [Required]
        [StringLength(4, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression(@"^([0-9]{3,4})$")]
        [DisplayName("Card security code (CVV)")]
        public string CardSecurityCode { get; set; }

        /// <summary>
        /// Refers to the person who owns a credit or debit card
        /// </summary>
        [Required]
        [StringLength(150)]
        [DisplayName("Card holder name")]
        public string CardHolderName { get; set; }
        
        
        /// <summary>
        /// Two-digit code for the month and the last two digits of the year
        /// E.g. Expiration Date November 2022 should be 11/22
        /// </summary>
        [Required]
        [StringLength(5, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)")]
        [DisplayName("Expiration date")]
        public string ExpirationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Creating date to compare on the first day of a month. Expiration date is valid till the end of the month.
            var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

            if (DateTime.TryParseExact(ExpirationDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                if (dateValue < currentDate)
                {
                    yield return new ValidationResult(
                        $"Expiration date is not valid",
                        new[] {nameof(ExpirationDate)});
                }
            }
            else
            {
                yield return new ValidationResult(
                    $"Expiration date has not valid format",
                    new[] {nameof(ExpirationDate)});
            }
        }
    }
}