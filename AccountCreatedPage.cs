using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class AccountCreatedPage : BasePage
    {
        private IWebDriver _driver;
        public AccountCreatedPage(IWebDriver driver) : base(driver)
        {
            _driver = base.Driver;
        }

        public IWebElement AccountCreatedMessage => _driver.FindElement(By.CssSelector("h2[data-qa='account-created']"));
        public IWebElement AccountDeletedMessage => _driver.FindElement(By.CssSelector("h2[data-qa='account-deleted']"));
        public IWebElement ContinueButton => _driver.FindElement(By.CssSelector("a[data-qa='continue-button']"));

        public HomePage ClickContinueButton()
        {
            ContinueButton.Click();
            return new HomePage(_driver);
        }
    }
}
