using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public class Select2Request : ISelect2Request
    {
        public string Query { get; set; }
        private int? pageSize;
        public int PageSize
        {
            get
            {
                return pageSize ?? 30;
            }
            set
            {
                pageSize = value;
            }
        }
        private int? pageNumber;
        public int PageNumber
        {
            get
            {
                return pageNumber ?? 1;
            }
            set
            {
                pageNumber = value;
            }
        }

    }
}
