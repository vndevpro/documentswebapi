using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace Rabbit.Documents.DataRavenDb.Extensions
{
    public static class AdvancedSessionOperationsExtensions
    {
        public static async Task<List<T>> StreamAsyncToList<T>(this IAsyncAdvancedSessionOperations sessionAdvanced, IRavenQueryable<T> query, CancellationToken cancellationToken = default)
        {
            var results = new List<T>();
            var queryResult = await sessionAdvanced.StreamAsync(query, out var stats, cancellationToken);

            while (await queryResult.MoveNextAsync())
            {
                results.Add(queryResult.Current.Document);
            }

            return results;
        }

        public static List<T> StreamToList<T>(this IAdvancedSessionOperations sessionAdvanced, IQueryable<T> query)
        {
            var results = new List<T>();
            var queryResult = sessionAdvanced.Stream(query);

            while (queryResult.MoveNext())
            {
                results.Add(queryResult.Current.Document);
            }

            return results;
        }
    }
}
