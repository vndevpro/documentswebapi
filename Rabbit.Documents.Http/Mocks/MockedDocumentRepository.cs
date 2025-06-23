using Rabbit.Documents.Domain.Entities;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Http.Mocks
{
    public class MockedDocumentRepository : IDocumentRepository
    {
        private readonly List<Document> _documents = [];

        public static IDocumentRepository Instance { get; } = new MockedDocumentRepository();

        private MockedDocumentRepository()
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

        public Document? GetById(Guid id)
        {
            return _documents.FirstOrDefault(d => d.Id == id);
        }

        public Document Create(Document document)
        {
            _documents.Add(document);

            return document;
        }

        public IEnumerable<Document> GetAll(int? page, int? pageSize)
        {
            return _documents;
        }

        public Document Update(Document aggregate)
        {
            // DO NOTHING
            return aggregate;
        }
    }
}
