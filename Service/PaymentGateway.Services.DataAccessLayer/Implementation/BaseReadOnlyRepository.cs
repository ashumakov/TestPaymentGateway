using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Services.DataAccessLayer.Implementation
{
    public abstract class BaseReadOnlyRepository<TModel, TId, TDbContext> : BaseRepository<TModel, TId, TDbContext>
        where TModel : class, IModel<TId>
        where TDbContext : DbContext
    {
        protected BaseReadOnlyRepository(TDbContext dbContext) : base(dbContext)
        { }

        public virtual async Task<TModel> GetAsync(TId entityId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id.ToString() == entityId.ToString());
        }

        public virtual async Task<IEnumerable<TModel>> QueryAsync(Expression<Func<TModel, bool>> filter = null)
        {
            if (filter != null)
                return await DbSet.Where(filter).ToListAsync();

            return await DbSet.ToListAsync();
        }
    }
}