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
        public IWebElement NameNewUser => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        public IWebElement EmailAddressNewUser => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        public IWebElement SignupButton => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
        public IWebElement EmailAddressExistingUser => _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        public IWebElement Password => _driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));




        public void ClickNameNewUserTextBox()
        {
            NameNewUser.Click();
        }

        public void ClickEmailAddressNewUserTextBox()
        {
            EmailAddressNewUser.Click();
        }

        public void ClickEmailExistingUserTextBox()
        {
            EmailAddressExistingUser.Click();
        }

        public void ClickPasswordTextBox()
        {
            Password.Click();
        }

        public HomePage ClickLoginButton()
        {
            LoginButton.Click();
            return new HomePage(_driver);
        }

        public void SignupNewUser(string username, string email)
        {
            ClickNameNewUserTextBox();
            NameNewUser.SendKeys(username);
            ClickEmailAddressNewUserTextBox();
            EmailAddressNewUser.SendKeys(email);
        }

        public void LoginExistingUser(string email, string password)
        {
            ClickEmailExistingUserTextBox();
            EmailAddressExistingUser.SendKeys(email);
            ClickPasswordTextBox();
            Password.SendKeys(password);
        }

        public AccountInformationPage ClickSignupButton()
        {
            SignupButton.Click();
            return new AccountInformationPage(_driver);
        }
    }
}
