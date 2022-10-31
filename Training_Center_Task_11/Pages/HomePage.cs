using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_11.Pages
{
    public class HomePage : MainPage
    {
        private IWebDriver _driver;

        private IWebElement _gdprButton;
        private IWebElement _loginLink;

        const string GDPR_BUTTON_LOCATOR = "button[data-text='Accept all']";
        const string LOGIN_LINK_LOCATOR = "Log in";
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            GoToLoginPage();
            return new LogInPage(_driver);
        }

        public void AcceptGRPR()
        {
            try
            {
                _gdprButton = _driver.FindElement(By.CssSelector(GDPR_BUTTON_LOCATOR), Constants.WebDriverWaitTime);
                _gdprButton.Click();
            }
            catch (Exception)
            {
            }
        }

        public void GoToLoginPage()
        {
            _loginLink = _driver.FindElement(By.LinkText(LOGIN_LINK_LOCATOR), Constants.WebDriverWaitTime);
            _loginLink.Click();
        }
    }
}
