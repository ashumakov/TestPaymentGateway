using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public abstract class BaseRepository<TModel, TId, TDbContext>
        where TModel : class, IModel<TId>
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;

        protected BaseRepository(TDbContext dbContext)
        {
            Context = dbContext;
        }

        protected virtual DbSet<TModel> DbSet => Context.Set<TModel>();
    }
}