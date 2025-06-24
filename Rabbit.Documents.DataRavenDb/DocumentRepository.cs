using Rabbit.Documents.Domain.Entities;
using Rabbit.Documents.Domain.Repositories;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Rabbit.Documents.RavenDbData
{
    public class DocumentRepository(IAsyncDocumentSession documentSession) : RepositoryBase<Document, string>, IDocumentRepository
    {
        public override async Task<Document> CreateOrUpdateAsync(Document aggregate)
        {
            await documentSession.StoreAsync(aggregate, aggregate.Id);
            await documentSession.SaveChangesAsync();
            return aggregate;
        }

        public override async Task DeleteAsync(string id)
        {
            documentSession.Delete(id.ToString());
            await documentSession.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Document>> GetAllAsync(int? page, int? pageSize)
        {
            return await documentSession.Query<Document>()
                .Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
                .Take(pageSize.GetValueOrDefault(10))
                .ToListAsync();
        }

        public override async Task<Document?> GetByIdAsync(string id)
        {
            return await documentSession.LoadAsync<Document>(id);
        }
    }
}
