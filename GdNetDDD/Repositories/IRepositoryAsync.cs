using GdNetDDD.Common;
using GdNetDDD.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GdNetDDD.Repositories
{
    public interface IRepositoryAsync<TAggregate, TId> : IRepository where TAggregate : IAggregate<TId>
    {
        Task<TAggregate> CreateOrUpdateAsync(TAggregate aggregate);

        Task DeleteAsync(TId id);

        Task<TAggregate> GetByIdAsync(TId id);

        Task<IEnumerable<TAggregate>> GetAllAsync(int? page, int? pageSize);

        Task<PaginatedList<TAggregate>> GetListAsync(int? page, int? pageSize);
    }
}
