using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.ViewEngines
{
    public class CSharpRazorViewEngine : RazorViewEngine
    {
        public CSharpRazorViewEngine()
        {
            AreaViewLocationFormats = new[]
             {
             "~/Areas/{2}/Views/{1}/{0}.cshtml",
             "~/Areas/{2}/Views/Shared/{0}.cshtml"
             };
            AreaMasterLocationFormats = new[]
             {
             "~/Areas/{2}/Views/{1}/{0}.cshtml",
             "~/Areas/{2}/Views/Shared/{0}.cshtml"
             };
            AreaPartialViewLocationFormats = new[]
             {
             "~/Areas/{2}/Views/{1}/{0}.cshtml",
             "~/Areas/{2}/Views/Shared/{0}.cshtml"
             };
            ViewLocationFormats = new[]
             {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
             };
            MasterLocationFormats = new[]
             {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
             };
            PartialViewLocationFormats = new[]
             {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
             };
        }
    }
}
