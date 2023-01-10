using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = base.Driver;
        }
        public IWebElement NameTextBox => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        public IWebElement EmailAddressTextBox => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        public IWebElement SignupButton => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

        public void ClickNameTextBox()
        {
            NameTextBox.Click();
        }

        public void ClickEmailAddressTextBox()
        {
            EmailAddressTextBox.Click();
        }

        public AccountInformationPage ClickSignupButton()
        {
            SignupButton.Click();
            return new AccountInformationPage(_driver);
        }
    }
}
