using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public static class ClickExtensions
    {
        public static void ClickAndWaitForLoad(this IWebDriver driver, string elementID)
        {
            driver.ClickAndWaitForLoad(By.Id(elementID));
        }

        public static void ClickAndWaitForLoad(this IWebDriver driver, By by)
        {
            var element = driver.FindElement(by);
            using (driver.WaitForLoad())
                element.Click();
        }

        public static void Click(this IWebDriver driver, string elementID)
        {
            driver.Click(By.Id(elementID));
        }

        public static void Click(this IWebDriver driver, By by)
        {
            driver.ScrollTo(by);
            var element = driver.FindElement(by);
            element.Click();
        }

        public static void TryClick(this IWebDriver driver, string elementID)
        {
            driver.TryClick(By.Id(elementID));
        }

        public static void TryClick(this IWebDriver driver, By by)
        {
            var element = driver.FindElement(by);
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5.00));
            wait.Until(driver1 => driver.tryClick(by));
        }


        private static bool tryClick(this IWebDriver driver, By by)
        {
            try
            {
                driver.Click(by);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
