using OpenQA.Selenium;

namespace Training_Center_Task_11
{
    public class BasePage
    {
        protected string _url = @"https://www.yandex.com/";

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.URL = _url;
        }

        public string URL { get; set; }

        public IWebDriver Driver { get; set; }
    }
}
