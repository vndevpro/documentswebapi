namespace Rabbit.Documents.Application
{
    public class PaginatedResult<T> : PaginatedResult
    {
        public required IReadOnlyCollection<T> Items { get; init; }
    }

    public abstract class PaginatedResult
    {
        public int PageNumber { get; init; }

        public int TotalPages { get; init; }

        public int PageSize { get; init; }

        public long TotalCount { get; init; }

        public static PaginatedResult<T> Create<T>(IList<T> items, long totalCount, int pageNumber, int pageSize)
        {
            var result = new PaginatedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                TotalCount = totalCount,
                Items = items.AsReadOnly()
            };

            return result;
        }
    }
}
