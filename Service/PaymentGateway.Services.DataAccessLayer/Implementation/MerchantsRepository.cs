using System;
using PaymentGateway.Core.DataAccess.Context;
using PaymentGateway.Core.DataAccess.Models;
using PaymentGateway.Services.DataContracts.Contracts;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public class MerchantsRepository : BaseReadOnlyRepository<Merchant, Guid, GatewayContext>, IMerchantsRepository
    {
        public MerchantsRepository(GatewayContext dbContext) : base(dbContext)
        {
        }
    }
}