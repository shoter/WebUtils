using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> query, PagingParam pp)
        {
            return pp.Apply(query);
        }

        
    }
}
