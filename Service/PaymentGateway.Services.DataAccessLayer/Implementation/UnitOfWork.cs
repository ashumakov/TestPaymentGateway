using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.DataAccess.Context;
using PaymentGateway.Services.DataContracts.Contracts;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        public UnitOfWork(GatewayContext dbContext, IMerchantsRepository merchantsRepository, IPaymentsRepository paymentsRepository)
        {
            _dbContext = dbContext;
            Merchants = merchantsRepository;
            Payment = paymentsRepository;
        }

        public IMerchantsRepository Merchants { get; }
        public IPaymentsRepository Payment { get; }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}