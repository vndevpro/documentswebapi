using GdNetDDD.Common;
using GdNetDDD.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GdNetDDD.Repositories
{
    /// <summary>
    /// Provides an abstraction for real repository classes.
    /// This include both Async and sync interfaces but only requires to implement the async one.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class RepositoryBase<TAggregate, TId> : IRepositoryAsync<TAggregate, TId>, IRepository<TAggregate, TId> where TAggregate : IAggregate<TId>
    {
        public virtual TAggregate CreateOrUpdate(TAggregate aggregate)
        {
            return CreateOrUpdateAsync(aggregate).GetAwaiter().GetResult();
        }

        public virtual void Delete(TId id)
        {
            DeleteAsync(id).GetAwaiter().GetResult();
        }

        public virtual IEnumerable<TAggregate> GetAll(int? page, int? pageSize)
        {
            return GetAllAsync(page, pageSize).GetAwaiter().GetResult();
        }

        public virtual TAggregate GetById(TId id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public PaginatedList<TAggregate> GetList(int? page, int? pageSize)
        {
            return GetListAsync(page, pageSize).GetAwaiter().GetResult();
        }

        public abstract Task<TAggregate> CreateOrUpdateAsync(TAggregate aggregate);

        public abstract Task DeleteAsync(TId id);

        public abstract Task<IEnumerable<TAggregate>> GetAllAsync(int? page, int? pageSize);

        public abstract Task<TAggregate> GetByIdAsync(TId id);

        public abstract Task<PaginatedList<TAggregate>> GetListAsync(int? page, int? pageSize);
    }
}
