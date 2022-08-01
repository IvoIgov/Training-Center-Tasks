using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center_Task_7.Inbox;

namespace Training_Center_Task_7.Pages.Home
{
    public class LogInPage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;
        private IWebElement _signInLink;
        private IWebElement _usernameTextBox;
        private IWebElement _passwordTextBox;
        private IWebElement _staySignedInCheckbox;
        private IWebElement _nextButton;
        private IWebElement _denyAllPersonalisedStatsButton;
        private IWebElement _closePersonalisedStatsButton;


        public LogInPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            _signInLink = _driver.FindElement(By.Id("login-signin"), WebDriverWaitTime);
        }

        public InboxPage Login(string username, string password)
        {
            _driver.Wait(3000);
            _signInLink.Click();

            _usernameTextBox = _driver.FindElement(By.Id("login-username"), WebDriverWaitTime);
            _usernameTextBox.Click();
            _usernameTextBox.SendKeys(username);

            _staySignedInCheckbox = _driver.FindElement(By.CssSelector("label[for='persistent']"), WebDriverWaitTime);
            _staySignedInCheckbox.Click();

            _nextButton = _driver.FindElement(By.Id("login-signin"), WebDriverWaitTime);
            _nextButton.Click();

            _passwordTextBox = _driver.FindElement(By.Id("login-passwd"), WebDriverWaitTime);
            _passwordTextBox.SendKeys(password);

            _nextButton = _driver.FindElement(By.Id("login-signin"), WebDriverWaitTime);
            _nextButton.Click();

            try
            {
                _denyAllPersonalisedStatsButton = _driver.FindElement(By.Id("mail-decline-all-1"), WebDriverWaitTime);
                _denyAllPersonalisedStatsButton.Click();
                _closePersonalisedStatsButton = _driver.FindElement(By.CssSelector("button[class='btn primary done-button']"), WebDriverWaitTime);
                _closePersonalisedStatsButton.Click();
            }
            catch (Exception)
            {
            }

            return new InboxPage(_driver);
        }
    }
}
