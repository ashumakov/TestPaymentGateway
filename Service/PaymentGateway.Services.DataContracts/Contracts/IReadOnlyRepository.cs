using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface IReadOnlyRepository<TModel, TId> where TModel : IModel<TId>
    {
        Task<TModel> GetAsync(TId entityId);
        Task<IEnumerable<TModel>> QueryAsync(Expression<Func<TModel, bool>> filter = null);
    }
}