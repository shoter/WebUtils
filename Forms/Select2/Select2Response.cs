using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public class Select2Response : ISelect2Response
    {
        public int TotalCount { get; set; }

        public bool HasMorePages { get; set; }

        public List<ISelect2Item> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">Must have [string text] and [int id] field</param>
        /// <param name="request"></param>
        public Select2Response(IQueryable<ISelect2Item> query, ISelect2Request request)
        {
            TotalCount = query.Count();
            HasMorePages = request.PageNumber * request.PageSize <= TotalCount;
            Items = query.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
        }
    }
}
