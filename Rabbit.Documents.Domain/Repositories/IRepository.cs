using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public interface IRepository<TAggregate, TId> : IRepository where TAggregate : IAggregate<TId>
    {
        TAggregate CreateOrUpdate(TAggregate aggregate);

        void Delete(TId id);

        TAggregate? GetById(TId id);

        IEnumerable<TAggregate> GetAll(int? page, int? pageSize);
    }

    public interface IRepository
    {
    }
}
