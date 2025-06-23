namespace Rabbit.Documents.Domain.Entities
{
    public interface IAggregate<TId> : IAggregate, IEntity<TId>
    {
    }

    public interface IAggregate : IEntity
    {
    }
}
