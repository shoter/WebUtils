using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUtils.Scripts
{
    public static class ScriptInjector
    {
        private static IJavascriptRenderer javascriptRenderer;

        private static List<string> scripts
        {
            get
            {
                if (HttpContext.Current.Items.Contains(nameof(ScriptInjector)) == false)
                    HttpContext.Current.Items.Add(nameof(ScriptInjector), new List<string>());

                return (List<string>)HttpContext.Current.Items[nameof(ScriptInjector)];
            }
        }

        public static void SetJavascriptRenderer(IJavascriptRenderer renderer)
        {
            javascriptRenderer = renderer;
        }

        public static void AddScript(string src)
        {
            if(scripts.Contains(src) == false)
                scripts.Add(src);
        }

        public static void AddJavascript(string code)
        {
            javascriptRenderer.AddJavascript(code);
        }


        public static IHtmlString RenderScripts()
        {
            return System.Web.Optimization.Scripts.Render(scripts.ToArray());
        }

        public static IHtmlString RenderJavascriptCode()
        {
            return javascriptRenderer.RenderJavascript();
        }

    }
}
