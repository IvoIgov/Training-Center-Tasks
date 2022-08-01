using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Training_Center_Task_7
{
    public static class SeleniumWebDriverExtensions
    {
        public static void Wait(this IWebDriver driver, int time = 3000)
        {
            Thread.Sleep(time);
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
