using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils
{
    public class PagingParams
    {
        public int Page { get; set; }
        public int Records { get; set; } = 0;
        public int RecordsPerPage { get; set; } = 10;
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Records / (double)RecordsPerPage);
            }
        }


        public PagingParams() { }


        public IQueryable<T> Apply<T>(IQueryable<T> query)
        {
            Page = query.Count();

            return query.Skip((PageCount - 1) * RecordsPerPage)
                .Take(RecordsPerPage);
        }


    }
}
