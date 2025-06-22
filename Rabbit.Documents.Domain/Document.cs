namespace Rabbit.Documents.Domain
{
    public class Document
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public static Document Create(string title, string? description)
        {
            return new Document
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
