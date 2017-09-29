using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public interface ISelect2Response
    {
        int TotalCount { get; }
        /// <summary>
        /// true if there is more data to load by request with PageNumber+1
        /// </summary>
        bool HasMorePages { get; }
        /// <summary>
        /// Every item must have [string text] and [int id] field.
        /// </summary>
        List<ISelect2Item> Items { get; }

    }
}
