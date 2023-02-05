using OpenQA.Selenium;

namespace Training_Center_Task_15.Pages
{

    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }
    }
}
