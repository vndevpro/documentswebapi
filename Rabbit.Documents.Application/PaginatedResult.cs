namespace GdNetDDD.Common
{
    public class PaginatedResult<T>
    {
        public required IReadOnlyCollection<T> Items { get; init; }

        public int PageNumber { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public long TotalCount { get; private set; }

        public static PaginatedResult<T> Create(IList<T> items, long totalCount, int pageNumber, int pageSize)
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
