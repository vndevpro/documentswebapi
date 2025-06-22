namespace Rabbit.Documents.Application.Commands
{
    public class CreateDocumentInputModel
    {
        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
