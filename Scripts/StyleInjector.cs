using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebUtils.Scripts
{
    public static class StyleInjector
    {
        private static List<string> styles
        {
            get
            {
                if (HttpContext.Current.Items.Contains(nameof(StyleInjector)) == false)
                    HttpContext.Current.Items.Add(nameof(StyleInjector), new List<string>());

                return (List<string>)HttpContext.Current.Items[nameof(StyleInjector)];
            }
        }



        public static void AddStyle(string src)
        {
            if (styles.Contains(src) == false)
                styles.Add(src);
        }


        public static IHtmlString RenderStyles()
        {
            return System.Web.Optimization.Styles.Render(styles.ToArray());
        }
    }
}
