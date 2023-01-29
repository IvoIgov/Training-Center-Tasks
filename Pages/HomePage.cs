using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
