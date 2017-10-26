using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Scripts
{
    public interface IJavascriptRenderer
    {
        void AddJavascript(string code);
        MvcHtmlString RenderJavascript();
    }
}
