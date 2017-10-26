using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils
{
    public class PagingParam
    {
        public int PageNumber { get; set; } = 1;
        public int Records { get; set; } = 0;
        public int RecordsPerPage { get; set; } = 10;
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Records / (double)RecordsPerPage);
            }
        }


        public PagingParam() { }
        public PagingParam(int page, int recordsPerPage)
        {
            PageNumber = page;
            RecordsPerPage = recordsPerPage;
        }


        public IEnumerable<T> Apply<T>(IEnumerable<T> query)
        {
            Records = query.Count();

            if (PageNumber < 1)
                PageNumber = 1;
            if (PageNumber > PageCount)
                PageNumber = PageCount;



            if (Records > 0)
                return query
                    .Skip((PageNumber - 1) * RecordsPerPage)
                    .Take(RecordsPerPage);
            else return query;
        }

        public IQueryable<T> Apply<T>(IQueryable<T> query)
        {
            Records = query.Count();

            if (PageNumber < 1)
                PageNumber = 1;
            if (PageNumber > PageCount)
                PageNumber = PageCount;


            if (Records > 0)
                return query
                    .Skip((PageNumber - 1) * RecordsPerPage)
                    .Take(RecordsPerPage);
            else return query;
        }


    }
}
