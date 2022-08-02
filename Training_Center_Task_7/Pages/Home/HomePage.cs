﻿using OpenQA.Selenium;

namespace Training_Center_Task_7.Pages.Home
{
    public class HomePage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;

        const string GDPR_BUTTON_LOCATOR = "button[class='btn primary']";
        const string MAIL_BUTTON_LOCATOR = "ybarMailLink";

        private IWebElement _gdprButton;
        private IWebElement _mailButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void AcceptGRPR()
        {
            try
            {
                _gdprButton = _driver.FindElement(By.CssSelector(GDPR_BUTTON_LOCATOR), WebDriverWaitTime);
                _gdprButton.Click();
            }
            catch (Exception)
            {
            }
        }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            _mailButton = _driver.FindElement(By.Id(MAIL_BUTTON_LOCATOR), WebDriverWaitTime);
            _mailButton.Click();
            return new LogInPage(_driver);
        }
    }
}
