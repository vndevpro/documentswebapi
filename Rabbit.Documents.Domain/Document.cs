namespace Rabbit.Documents.Domain
{
    public class Document
    {
        public Guid Id { get; init; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; init ; }

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

        public void ChangeDetails(string title, string? description)
        {
            Title = title;
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
