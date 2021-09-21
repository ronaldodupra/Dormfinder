using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DormFinder.Web.Core.Paging;

namespace DormFinder.Web.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> keySelector, string direction)
        {
            if (direction == "desc")
            {
                return query.OrderByDescending(keySelector);
            }
            else
            {
                return query.OrderBy(keySelector);
            }
        }

        public static IOrderedQueryable<T> ThenBy<T, TKey>(this IOrderedQueryable<T> query, Expression<Func<T, TKey>> keySelector, string direction)
        {
            if (direction == "desc")
            {
                return query.ThenByDescending(keySelector);
            }
            else
            {
                return query.ThenBy(keySelector);
            }
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, PageOptions options)
        {
            if (options.All)
            {
                return query;
            }

            return query.Skip(options.Offset).Take(options.PageSize);
        }

        [Obsolete]
        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, PageOptions options, IEnumerable<string> sortables = null)
        {
            if (string.IsNullOrWhiteSpace(options.Sort) || string.IsNullOrWhiteSpace(options.Direction))
            {
                return query;
            }

            var found = sortables?.Any(s => string.Equals(s, options.Sort, StringComparison.OrdinalIgnoreCase));

            if (!found ?? false)
            {
                return query;
            }

            var propertyInfo = typeof(T).GetProperty(
                options.Sort,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (propertyInfo == null)
            {
                return query;
            }

            if (options.Direction == "desc")
            {
                return query.OrderByDescending(x => propertyInfo.GetValue(x, null));
            }
            else
            {
                return query.OrderBy(x => propertyInfo.GetValue(x, null));
            }
        }
    }
}
