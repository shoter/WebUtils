using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtils.EF;

namespace WebUtils.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> query, PagingParam pp)
        {
            return pp.Apply(query);
        }

        public static IQueryable<TSelect> Apply<T, TSelect>(this IQueryable<T> query, IDomSelector<T, TSelect> selector)
            where T : class
        {
            return selector.Select(query);
        }
    }
}
