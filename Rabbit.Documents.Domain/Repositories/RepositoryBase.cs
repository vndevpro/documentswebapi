using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public abstract class RepositoryBase<TAggregate, TId> : IRepositoryAsync<TAggregate, TId> where TAggregate : IAggregate<TId>
    {
        public TAggregate CreateOrUpdate(TAggregate aggregate)
        {
            return CreateOrUpdateAsync(aggregate).GetAwaiter().GetResult();
        }

        public void Delete(TId id)
        {
            DeleteAsync(id).GetAwaiter().GetResult();
        }

        public IEnumerable<TAggregate> GetAll(int? page, int? pageSize)
        {
            return GetAllAsync(page, pageSize).GetAwaiter().GetResult();
        }

        public TAggregate? GetById(TId id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public abstract Task<TAggregate> CreateOrUpdateAsync(TAggregate aggregate);

        public abstract Task DeleteAsync(TId id);

        public abstract Task<IEnumerable<TAggregate>> GetAllAsync(int? page, int? pageSize);

        public abstract Task<TAggregate?> GetByIdAsync(TId id);
    }
}
