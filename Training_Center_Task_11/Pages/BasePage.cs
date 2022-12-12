using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class BasePage
    {
        protected string _url = @"https://www.yandex.com/";

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            URL = _url;
        }

        public string URL { get; set; }

        public IWebDriver Driver { get; set; }
    }
}
