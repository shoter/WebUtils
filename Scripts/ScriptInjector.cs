using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUtils.Scripts
{
    public class ScriptInjector
    {

        private static List<string> scripts
        {
            get
            {
                if (HttpContext.Current.Items.Contains(nameof(ScriptInjector)) == false)
                    HttpContext.Current.Items.Add(nameof(ScriptInjector), new List<string>());

                return (List<string>)HttpContext.Current.Items[nameof(ScriptInjector)];
            }
        }

        public static void AddScript(string src)
        {
            scripts.Add(src);
        }


        public static IHtmlString RenderScripts()
        {
            return System.Web.Optimization.Scripts.Render(scripts.ToArray());
        }

    }
}
