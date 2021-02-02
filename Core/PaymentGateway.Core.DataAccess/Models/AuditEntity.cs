using System;

namespace PaymentGateway.Core.DataAccess.Models
{
    public class AuditEntity : BaseGuidModel
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
