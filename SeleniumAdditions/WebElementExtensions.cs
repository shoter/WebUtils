using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public static class WebElementExtensions
    {
        //Selenium originally also uses try/catch to check for that :O
        //https://stackoverflow.com/questions/25415849/check-if-a-webelement-is-stale-without-handling-an-exception
        //I also do not care here for performance in most cases. Because it will be used for waiting so it's good solution for my needs
        public static bool IsStale(this IWebElement element)
        {
            try
            {
                element.Click();
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }
    }
}
