using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_11.Pages
{
    public class InboxPage : MainPage
    {
        private IWebDriver _driver;

        private IWebElement _composeButton;
        private IWebElement _usernameLink;
        private IWebElement _logoutLink;



        const string COMPOSE_BUTTON_LOCATOR = "a[href='#compose']";
        const string USERNAME_LINK_LOCATOR = "span[class='user-account__name']";
        const string LOGOUT_LINK_LOCATOR = "a[aria-label='Log out']";



        public InboxPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            _composeButton = _driver.FindElement(By.CssSelector(COMPOSE_BUTTON_LOCATOR), Constants.WebDriverWaitTime);
            _usernameLink = _driver.FindElement(By.CssSelector(USERNAME_LINK_LOCATOR), Constants.WebDriverWaitTime);
        }

        public LogInPage Logout()
        {
            ClickUsernameLink();
            _driver.Wait(2000);
            ClickLogoutLink();
            _driver.Wait(2000);

            return new LogInPage(_driver);
        }

        public bool CheckComposeButtonPresent()
        {
            return _composeButton.Displayed;
        }

        public string CheckUsernameTextCorrect()
        {
            return _usernameLink.Text;
        }

        public void ClickUsernameLink()
        {
            _usernameLink.Click();
        }

        public void ClickLogoutLink()
        {
            _logoutLink = _driver.FindElement(By.CssSelector(LOGOUT_LINK_LOCATOR), Constants.WebDriverWaitTime);
            _logoutLink.Click();
        }
    }
}
