using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public static class WaitExtensions
    {
        public static PageLoadWaiter WaitForLoad(this IWebDriver driver)
        {
            return new PageLoadWaiter(driver);
        }

        public static void WaitSeconds(this IWebDriver driver, int seconds)
        {
            driver.Wait(TimeSpan.FromSeconds(seconds));
        }

        public static void Wait(this IWebDriver driver, TimeSpan timeSpan)
        {
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }

        public static void WaitUntilClickable(this IWebDriver driver, string elementID)
        {
            driver.WaitUntilClickable(By.Id(elementID));
        }

        public static void WaitUntilClickable(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.IsElementClickable(by));
        }

    }
}
