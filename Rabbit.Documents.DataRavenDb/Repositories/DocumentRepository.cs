using GdNetDDD.Common;
using GdNetDDD.Repositories;
using Rabbit.Documents.DataRavenDb.Extensions;
using Rabbit.Documents.DataRavenDb.Indexes;
using Rabbit.Documents.Domain.Entities;
using Rabbit.Documents.Domain.Repositories;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using System.Linq.Expressions;

namespace Rabbit.Documents.DataRavenDb.Repositories
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

        public override async Task<long> CountAllAsync()
        {
            return await documentSession.Query<Document>().LongCountAsync();
        }

        public override async Task<Document> GetByIdAsync(string id)
        {
            return await documentSession.LoadAsync<Document>(id);
        }

        public override async Task<PaginatedList<Document>> GetListAsync(int? page, int? pageSize)
        {
            var query = documentSession.Query<Document>();

            return await query.GetPaginatedList(page, pageSize);
        }

        public async Task<PaginatedList<Document>> SearchAsync(string searchTerms, int? page, int? pageSize)
        {
            var query = documentSession.Query<Document, SearchableDocumentsIndex>()
                .Search(x => x.Title, searchTerms, @operator: SearchOperator.And)
                .Search(x => x.Description, searchTerms, @operator: SearchOperator.And);

            return await query.GetPaginatedList(page, pageSize);
        }

        public async Task<PaginatedList<Document>> SearchAsync(IDictionary<DocumentSearchableField, string> searchFields, int? page, int? pageSize)
        {
            return await GetSearchableQuery().GetPaginatedList(page, pageSize);

            IRavenQueryable<Document> GetSearchableQuery()
            {
                var query = documentSession.Query<Document, SearchableDocumentsIndex>();

                foreach (var searchField in searchFields)
                {
                    var fieldSelector = GetFieldSelector(searchField.Key);
                    query = query.Search(fieldSelector, searchField.Value, options: SearchOptions.And, @operator: SearchOperator.And);
                }

                return query;
            }

            Expression<Func<Document, object?>> GetFieldSelector(DocumentSearchableField searchableField)
            {
                return searchableField switch
                {
                    DocumentSearchableField.Title => x => x.Title,
                    DocumentSearchableField.Description => x => x.Description,
                    _ => throw new NotImplementedException($"Not implemented for the searchable field {searchableField}."),
                };
            }
        }
    }
}
