using System;

namespace PaymentGateway.Core.DataAccess.Models
{
    public class BaseGuidModel : IModel<Guid>
    {
        public Guid Id { get; set; }

        public BaseGuidModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
