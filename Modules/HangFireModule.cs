using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace WebUtils.Modules
{
    public class HangFireModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAuthorizeRequest += onPostAuthorizeRequest;
        }

        public void Dispose() { }

        private void onPostAuthorizeRequest(object sender, EventArgs eventArgs)
        {
            var context = ((HttpApplication)sender).Context;
            var request = context.Request;
            if ((request != null
                 && request.AppRelativeCurrentExecutionFilePath != null
                 && request.AppRelativeCurrentExecutionFilePath.StartsWith("~/hangfire", StringComparison.InvariantCultureIgnoreCase)))
            {
                context.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }
    }
}
