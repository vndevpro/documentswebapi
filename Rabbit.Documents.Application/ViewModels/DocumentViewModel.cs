namespace Rabbit.Documents.Application.ViewModels
{
    public class DocumentViewModel
    {
        public required string Id { get; init; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public required DateTime CreatedAt { get; init; }

        public required DateTime UpdatedAt { get; set; }
    }
}
