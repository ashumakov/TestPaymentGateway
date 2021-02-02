using System;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface IMerchantsRepository: IReadOnlyRepository<Merchant, Guid>
    {
        
    }
}