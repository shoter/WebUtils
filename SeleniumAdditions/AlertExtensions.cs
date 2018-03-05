using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.SeleniumAdditions
{
    public static class AlertExtensions
    {
        public static void WaitForAndAcceptAlert(this IWebDriver driver)
        {
            IAlert alert = driver.WaitForAlert();
            if (alert == null)
                throw new Exception("Alert not found!");
            alert.Accept();


        }

        //https://stackoverflow.com/questions/19206894/how-to-implement-expectedconditions-alertispresent-in-c-sharp - thanks
        public static IAlert WaitForAlert(this IWebDriver driver)
        {
            IAlert alert = null;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            try
            {
                alert = wait.Until(d =>
                {
                    try
                    {
                        // Attempt to switch to an alert
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        // Alert not present yet
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException) { alert = null; }

            return alert;
        }
    }
}
