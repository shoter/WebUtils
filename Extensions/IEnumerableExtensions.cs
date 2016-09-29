using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Apply<T>(this IEnumerable<T> query, PagingParam pp)
        {
            return pp.Apply(query);
        }
    }
}
