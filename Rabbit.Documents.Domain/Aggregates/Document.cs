using GdNetDDD.Entities;

namespace Rabbit.Documents.Domain.Entities
{
    public class Document : IAggregate<string>
    {
        public string Id { get; init; } = default!;

        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string CreatedBy { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }

        public static Document Create(string creatorId, string title, string? description)
        {
            return new Document
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Description = description,
                CreatedBy = creatorId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void ChangeDetails(string title, string? description)
        {
            Title = title;
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
