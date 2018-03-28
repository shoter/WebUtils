using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public class PageLoadWaiter : IDisposable
    {
        IWebElement body;
        IWebDriver driver;
        public PageLoadWaiter(IWebDriver driver)
        {
            this.driver = driver;
            body = driver.FindElement(By.TagName("body"));
        }

        public void Dispose()
        {
            waitForBodyStale();
            waitForPageLoad();
            Thread.Sleep(100);
        }

        private void waitForPageLoad()
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        private void waitForBodyStale()
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => body.IsStale());
        }
    }
}
