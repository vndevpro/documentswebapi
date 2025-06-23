namespace Rabbit.Documents.Domain.Entities
{
    public interface IEntity<TId> : IEntity
    {
        TId Id { get; init; }
    }

    public interface IEntity
    {
    }
}
