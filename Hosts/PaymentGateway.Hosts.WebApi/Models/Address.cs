using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Hosts.WebApi.Models
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// City
        /// </summary>
        [StringLength(maximumLength:100) ]
        public string City { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [StringLength(maximumLength:100) ]
        public string Country { get; set; }

        /// <summary>
        /// State. Applicable for USA
        /// </summary>
        [StringLength(2)]
        [RegularExpression(@"^(([Aa][EeLlKkSsZzRr])|([Cc][AaOoTt])|([Dd][EeCc])|([Ff][MmLl])|([Gg][AaUu])|([Hh][Ii])|([Ii][DdLlNnAa])|([Kk][SsYy])|([Ll][Aa])|([Mm][EeHhDdAaIiNnSsOoTt])|([Nn][EeVvHhJjMmYyCcDd])|([Mm][Pp])|([Oo][HhKkRr])|([Pp][WwAaRr])|([Rr][Ii])|([Ss][CcDd])|([Tt][NnXx])|([Uu][Tt])|([Vv][TtIiAa])|([Ww][AaVvIiYy]))$")]
        public string State { get; set; }

        /// <summary>
        /// Street, building and apt number
        /// </summary>
        [StringLength(maximumLength:150) ]
        public string Street { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        //TODO need to verify different postal code formats
        public string Zip { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [StringLength(maximumLength:100) ]
        [Phone]
        public string Phone { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [StringLength(maximumLength:100) ]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [StringLength(maximumLength:100) ]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [StringLength(maximumLength:100) ]
        public string Email { get; set; }

    }
}
