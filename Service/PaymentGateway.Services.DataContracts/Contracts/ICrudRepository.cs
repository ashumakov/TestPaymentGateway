using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface ICrudRepository<TModel, TId> : IReadOnlyRepository<TModel, TId>
        where TModel : IModel<TId>
    {
        TModel Create(TModel entity);

        void Update(TModel entity);

        void Delete(TId entityId);
    }
}