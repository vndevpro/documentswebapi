namespace Rabbit.Documents.Application.ViewModels
{
    public class DocumentViewModel
    {
        public string Id { get; init; } = default!;

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }
    }
}
