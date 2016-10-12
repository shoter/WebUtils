using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Extensions
{
    public static class IEnumExtensions
    {
        /// <summary>
        /// Creates SelectListItem from all enum values.
        /// Uses stringifier func to name each enum value
        /// </summary>
        public static List<SelectListItem> ToSelectListItems<T>(Func<T, string> stringifier)
            where T : struct, IConvertible
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (T t in Enum.GetValues(typeof(T)))
            {
                Enum test = Enum.Parse(typeof(T), t.ToString()) as Enum;
                int value = Convert.ToInt32(test); // x is the integer value of enum

                list.Add(new SelectListItem()
                {
                    Value = value.ToString(),
                    Text = stringifier(t)
                });
            }

            return list;
        }
    }
}
