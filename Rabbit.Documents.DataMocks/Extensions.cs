using GdNetDDD.Common;
using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.DataMocks
{
    static class Extensions
    {
        public static PaginatedList<Document> GetPaginatedList(this IEnumerable<Document> source, int? page, int? pageSize)
        {
            var aPage = page.GetValueOrDefault(0);
            var aPageSize = pageSize.GetValueOrDefault(10);
            var pagedDocuments = source.Skip(aPage * aPageSize)
                .Take(aPageSize)
                .ToList();
            return PaginatedList<Document>.Create(pagedDocuments, source.Count(), aPage, aPageSize);
        }
    }
}
