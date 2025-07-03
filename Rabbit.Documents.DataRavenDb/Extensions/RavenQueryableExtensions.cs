using GdNetDDD.Common;
using GdNetDDD.Entities;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;

namespace Rabbit.Documents.DataRavenDb.Extensions
{
    public static class RavenQueryableExtensions
    {
        /// <summary>
        /// Get a paginated list of items from the queryable source.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="query">The source query</param>
        /// <param name="page">Page number, default to 0</param>
        /// <param name="pageSize">Page size, default to 10</param>
        /// <returns>A paginated list from whole source</returns>
        public static async Task<PaginatedList<T>> GetPaginatedList<T>(this IRavenQueryable<T> query, int? page, int? pageSize) where T : IEntity
        {
            var aPage = page.GetValueOrDefault(0);
            var aPageSize = pageSize.GetValueOrDefault(10);

            var items = await query.Statistics(out var stats)
                .Skip(aPage * aPageSize)
                .Take(aPageSize)
                .ToListAsync();

            return PaginatedList<T>.Create(items, stats.TotalResults, aPage, aPageSize);
        }
    }
}
