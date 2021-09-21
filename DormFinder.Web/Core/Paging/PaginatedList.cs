using System;
using System.Collections.Generic;
using System.Linq;

namespace DormFinder.Web.Core.Paging
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; }

        public int TotalCount { get; }

        public int PageNumber { get; }

        public PaginatedList(IEnumerable<T> items)
        {
            Items = items;
        }

        public PaginatedList(IEnumerable<T> items, int total)
            : this(items, total, 0, 0)
        {
        }

        public PaginatedList(IEnumerable<T> items, int total, int pageNumber, int pageSize)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalCount = total;
        }

        public PaginatedList<R> Select<R>(Func<T, R> func)
        {
            var items = Items.Select(func);

            return new PaginatedList<R>(items, TotalCount);
        }
    }
}
