using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public abstract class BaseCrudRepository<TModel, TId, TDbContext> : BaseReadOnlyRepository<TModel, TId, TDbContext>
        where TModel : class, IModel<TId>
        where TDbContext : DbContext
    {
        protected BaseCrudRepository(TDbContext dbContext) : base(dbContext)
        { }

        public virtual TModel Create(TModel entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual void Update(TModel entity)
        {
            var dbEntity = GetAsync(entity.Id).Result;        

            Context.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TId entityId)
        {
            var dbEntity = GetAsync(entityId).Result;

            DbSet.Remove(dbEntity);
        }
    }
}