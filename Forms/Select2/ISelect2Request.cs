using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public interface ISelect2Request
    {
        string Query { set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}
