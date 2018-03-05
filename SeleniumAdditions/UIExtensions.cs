using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public static class UIExtensions
    {
        public static void ScrollTo(this IWebDriver driver, By by)
        {
            IWebElement element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            driver.WaitUntilClickable(by);
        }

        public static void ScroolTo(this IWebDriver driver, IWebElement element)
        {

        }
    }
}
