using System;
using PaymentGateway.Core.DataAccess.Context;
using PaymentGateway.Core.DataAccess.Models;
using PaymentGateway.Services.DataContracts.Contracts;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public class PaymentsRepository : BaseCrudRepository<Payment, Guid, GatewayContext>, IPaymentsRepository
    {
        public PaymentsRepository(GatewayContext dbContext) : base(dbContext)
        {
        }
    }
}