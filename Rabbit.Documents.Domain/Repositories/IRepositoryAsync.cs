using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public interface IRepositoryAsync<TAggregate, TId> : IRepository<TAggregate, TId> where TAggregate : IAggregate<TId>
    {
        Task<TAggregate> CreateOrUpdateAsync(TAggregate aggregate);

        Task DeleteAsync(TId id);

        Task<TAggregate?> GetByIdAsync(TId id);

        Task<IEnumerable<TAggregate>> GetAllAsync(int? page, int? pageSize);
    }
}
