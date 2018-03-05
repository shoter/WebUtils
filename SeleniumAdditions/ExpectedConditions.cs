using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    class ExpectedConditions
    {
        public static Func<IWebDriver, IWebElement> IsElementClickable(By by)
        {
            return driver =>
            {
                var element = driver.FindElement(by);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}
