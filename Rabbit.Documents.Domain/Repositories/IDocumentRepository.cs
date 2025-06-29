using GdNetDDD.Common;
using GdNetDDD.Repositories;
using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Domain.Repositories
{
    public interface IDocumentRepository : IRepositoryAsync<Document, string>, IRepository<Document, string>
    {
        Task<PaginatedList<Document>> Search(string searchTerms, int? page, int? pageSize);
    }
}
