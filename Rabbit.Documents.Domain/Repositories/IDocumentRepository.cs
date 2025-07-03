using GdNetDDD.Common;
using GdNetDDD.Repositories;
using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public interface IDocumentRepository : IRepositoryAsync<Document, string>, IRepository<Document, string>
    {
        Task<PaginatedList<Document>> SearchAsync(string searchTerms, int? page, int? pageSize);

        Task<PaginatedList<Document>> SearchAsync(IDictionary<DocumentSearchableField, string> searchFields, int? page, int? pageSize);
    }
}
