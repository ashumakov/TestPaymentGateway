using System.Collections.Generic;

namespace PaymentGateway.Core.DataAccess.Models
{
    public class Merchant : AuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BankAccountNumber { get; set; }
        public string SigningKey { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
