namespace Rabbit.Documents.Domain
{
    public class DocumentsManager : IDocumentsManager
    {
        private readonly List<Document> _documents = [];

        public static DocumentsManager Instance { get; } = new DocumentsManager();

        private DocumentsManager()
        {
            _documents.AddRange(
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Document 1",
                    Description = "Description 1",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Document 2",
                    Description = "Description 2",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        public void Delete(Guid id)
        {
            var document = _documents.FirstOrDefault(d => d.Id == id);
            if (document != null)
            {
                _documents.Remove(document);
            }
        }

        public Document? Get(Guid id)
        {
            return _documents.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Document> GetAll()
        {
            return _documents;
        }

        public Document Add(Document document)
        {
            _documents.Add(document);

            return document;
        }

        public Document Update(Guid id, Document document)
        {
            // DO NOTHING HERE
            return document;
        }
    }
}
