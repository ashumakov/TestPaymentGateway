using System;
using System.Threading.Tasks;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IMerchantsRepository Merchants { get; }
        IPaymentsRepository Payment { get; }

        Task<int> CommitAsync();
    }
}