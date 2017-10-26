using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUtils.Scripts
{
    public class ScriptRenderer : IJavascriptRenderer
    {
        private static StringBuilder code
        {
            get
            {
                if (HttpContext.Current.Items.Contains(nameof(IJavascriptRenderer)) == false)
                    HttpContext.Current.Items.Add(nameof(IJavascriptRenderer),new StringBuilder());

                return (StringBuilder)HttpContext.Current.Items[nameof(IJavascriptRenderer)];
            }
        }

        public void AddJavascript(string code)
        {
            ScriptRenderer.code
                .Append(code)
                .Append(";");
        }

        public virtual MvcHtmlString RenderJavascript()
        {
            return MvcHtmlString.Create(code.ToString());
        }
    }
}
