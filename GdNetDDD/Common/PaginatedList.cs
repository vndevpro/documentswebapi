using GdNetDDD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GdNetDDD.Common
{
    public class PaginatedList<T> where T : IEntity
    {
        public IReadOnlyCollection<T> Items { get; private set; }

        /// <summary>
        /// Zero based, first page number is 0
        /// </summary>
        public int PageNumber { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public long TotalCount { get; private set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages - 1;

        /// <summary>
        /// Create a paginated list from the whole source items
        /// </summary>
        /// <param name="source">Collection of all available items. It will be paginated internally.</param>
        /// <param name="pageNumber">Page number, zero based</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A paginated list from the whole source items</returns>
        public static PaginatedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return Create(items, source.Count(), pageNumber, pageSize);
        }

        /// <summary>
        /// Create a paginated list from the paginated source items
        /// </summary>
        /// <param name="items">Paginated items</param>
        /// <param name="totalCount">Total size of the whole source items</param>
        /// <param name="pageNumber">Current page number, zero based</param>
        /// <param name="pageSize">Current page size</param>
        /// <returns>A paginated list from the paginated source items</returns>
        public static PaginatedList<T> Create(List<T> items, long totalCount, int pageNumber, int pageSize)
        {
            var pList = new PaginatedList<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                TotalCount = totalCount,
                Items = items.AsReadOnly()
            };

            return pList;
        }
    }
}
