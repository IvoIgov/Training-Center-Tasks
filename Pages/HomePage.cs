using OpenQA.Selenium;

namespace Training_Center_Task_15.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = Driver;
        }

        public IWebElement EmailOrPasswordIncorrectMessage => _driver.FindElement(By.XPath("//div/form/p[@style]"));
    }
}
