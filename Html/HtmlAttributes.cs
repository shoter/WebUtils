using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Html
{
    public class HtmlAttributes : Dictionary<string, string>
    {
        public HtmlAttributes(object obj)
        {
            if (obj != null)
            {
                var type = obj.GetType();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var name = propertyInfo.Name;
                    var value = propertyInfo.GetValue(obj).ToString();
                    Add(name, value);
                }
            }
        }
    }
}
