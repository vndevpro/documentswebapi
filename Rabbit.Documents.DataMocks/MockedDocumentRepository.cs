using GdNetDDD.Common;
using GdNetDDD.Repositories;
using Rabbit.Documents.Domain.Entities;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.DataMocks
{
    public class MockedDocumentRepository : RepositoryBase<Document, string>, IDocumentRepository
    {
        private readonly List<Document> _documents = [];

        public static IDocumentRepository Instance { get; } = new MockedDocumentRepository();

        private MockedDocumentRepository()
        {
            CreateSampleDocuments();
        }

        public override Task DeleteAsync(string id)
        {
            var document = _documents.FirstOrDefault(d => d.Id == id);

            if (document != null)
            {
                _documents.Remove(document);
            }

            return Task.CompletedTask;
        }

        public override Task<Document> GetByIdAsync(string id)
        {
            var document = _documents.First(d => d.Id == id);
            return Task.FromResult(document);
        }

        public override Task<Document> CreateOrUpdateAsync(Document document)
        {
            var existingDocument = _documents.FirstOrDefault(d => d.Id == document.Id);

            if (existingDocument == null)
            {
                _documents.Add(document);
            }

            return Task.FromResult(document);
        }

        public override Task<IEnumerable<Document>> GetAllAsync(int? page, int? pageSize)
        {
            return Task.FromResult(_documents.AsEnumerable());
        }

        public override Task<PaginatedList<Document>> GetListAsync(int? page, int? pageSize)
        {
            var aPage = page.GetValueOrDefault(0);
            var aPageSize = pageSize.GetValueOrDefault(10);

            var pagedDocuments = _documents.Skip(aPage * aPageSize).Take(aPageSize).ToList();
            var pl = PaginatedList<Document>.Create(pagedDocuments, _documents.Count, aPage, aPageSize);

            return Task.FromResult(pl);
        }

        private void CreateSampleDocuments()
        {
            _documents.AddRange(
                            new Document
                            {
                                Id = Guid.NewGuid().ToString(),
                                Title = "Document 1",
                                Description = "Description 1",
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            },
                            new Document
                            {
                                Id = Guid.NewGuid().ToString(),
                                Title = "Document 2",
                                Description = "Description 2",
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            }
                        );
        }
    }
}
