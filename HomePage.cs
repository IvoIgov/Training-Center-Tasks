using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = base.Driver;
        }
        public IWebElement SignUpLoginLink => _driver.FindElement(By.CssSelector("a[href='/login']"));

        public LoginPage ClickSignUpLoginLink()
        {
            SignUpLoginLink.Click();
            return new LoginPage(_driver);
        }
    }
}
