using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Scripts
{
    public class JqueryAfterInitScriptRenderer : ScriptRenderer
    {
        public override MvcHtmlString RenderJavascript()
        {
            string code = base.RenderJavascript().ToString();

            return MvcHtmlString.Create(string.Format("{0}{1}{2}",
                "$(() => {",
                code,
                "});"));
        }
    }
}
