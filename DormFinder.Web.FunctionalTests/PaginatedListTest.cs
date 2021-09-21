using System.Collections.Generic;

namespace DormFinder.Web.FunctionalTests
{
    public class PaginatedListTest<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }
    }
}
