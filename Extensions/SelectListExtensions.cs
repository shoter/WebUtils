using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Extensions
{
    public static class SelectListExtensions
    {
        public static List<SelectListItem> SelectValue(this List<SelectListItem> list, object value)
        {
            return
                list.Select(item => new SelectListItem()
                {
                    Disabled = item.Disabled,
                    Group = item.Group,
                    Text = item.Text,
                    Value = item.Value,
                    Selected = value.ToString() == item.Value
                }).ToList();
        }
     
    }
}
