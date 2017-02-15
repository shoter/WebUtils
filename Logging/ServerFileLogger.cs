using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Utilities.Logging;
using Utilities.StringDecorators;

namespace WebUtils.Logging
{
    public class ServerFileLogger : FileLogger
    {
        /// <summary>
        /// Example path: ~/Logs/LastLog.txt 
        /// </summary>
        /// <param name="pathToFile"></param>
        public ServerFileLogger(string pathToFile, params IStringDecorator[] decorators) : base(HostingEnvironment.MapPath(pathToFile), decorators)
        {
        }
    }
}
