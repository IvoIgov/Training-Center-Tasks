using OpenQA.Selenium;
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
        private IWebElement _usernameText;
        const string COMPOSE_BUTTON_LOCATOR = "a[href='#compose']";
        const string USERNAME_TEXT_LOCATOR = "span[class='user-account__name']";

        public InboxPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public bool CheckComposeButtonPresent()
        {
            _composeButton = _driver.FindElement(By.CssSelector(COMPOSE_BUTTON_LOCATOR), Constants.WebDriverWaitTime);

            return _composeButton.Displayed;
        }

        public string CheckUsernameTextCorrect()
        {
            _usernameText = _driver.FindElement(By.CssSelector(USERNAME_TEXT_LOCATOR), Constants.WebDriverWaitTime);

            return _usernameText.Text;
        }
    }
}
