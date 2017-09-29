using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public interface ISelect2Item
    {
        int id { get; set; }
        string text { get; set; }
    }
}
