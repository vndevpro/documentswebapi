using GdNetDDD.Common;
using GdNetDDD.Entities;

namespace GdNetDDD.Repositories
{
    public interface IRepository<TAggregate, TId> : IRepository where TAggregate : IAggregate<TId>
    {
        TAggregate CreateOrUpdate(TAggregate aggregate);

        void Delete(TId id);

        TAggregate GetById(TId id);

        long CountAll();

        PaginatedList<TAggregate> GetList(int? page, int? pageSize);
    }

    public interface IRepository
    {
    }
}
