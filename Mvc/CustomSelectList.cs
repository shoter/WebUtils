using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Mvc
{
    public class CustomSelectList : List<SelectListItem>
    {
        public CustomSelectList()
        {
        }

        public void Add(int value, string text, bool selected = false)
        {
            Add(new SelectListItem()
            {
                Selected = selected,
                Text = text,
                Value = value.ToString()
            });
        }

        public void Add(string value, string text, bool selected = false)
        {
            Add(new SelectListItem()
            {
                Selected = selected,
                Text = text,
                Value = value
            });
        }

        public CustomSelectList AddSelect()
        {
            Add("", "-- Select --", selected: true);
            return this;
        }

        public CustomSelectList AddItems<T>(IEnumerable<T> items, Func<T, int> valueFunc, Func<T, string> nameFunc)
        {
            foreach (var item in items)
                Add(valueFunc(item), nameFunc(item));

            return this;
        }

        public CustomSelectList AddNumbers(int start, int end)
        {
            for (int i = start; i <= end; ++i)
                Add(i, i.ToString());
            return this;
        }


    }
}
