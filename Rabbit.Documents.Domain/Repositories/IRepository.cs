using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public interface IRepository<TAggregate, TId> where TAggregate : IAggregate<TId>
    {
        TAggregate Create(TAggregate aggregate);

        TAggregate Update(TAggregate aggregate);

        void Delete(TId id);

        TAggregate? GetById(TId id);

        IEnumerable<TAggregate> GetAll(int? page, int? pageSize);
    }

    public interface IRepository
    {

    }
}
