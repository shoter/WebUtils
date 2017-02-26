using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Attributes
{
    public class IsLocalAttribute : ActionMethodSelectorAttribute
    {
        public bool Local { get; set; }
        public IsLocalAttribute(bool local = true)
        {
            Local = local;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsLocal == Local;
        }
    }
}
