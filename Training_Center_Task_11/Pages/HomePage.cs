﻿using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement _gdprButton;
        private IWebElement _loginLink;

        const string GDPR_BUTTON_LOCATOR = "button[data-text='Accept all']";
        const string LOGIN_LINK_LOCATOR = "Log in";
        public HomePage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public IWebElement GDPRButton { get; set; }
        public IWebElement LoginLink { get; set; }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            GoToLoginPage();
            return new LogInPage(Driver);
        }

        public void AcceptGRPR()
        {
            _gdprButton = Driver.FindElement(By.CssSelector(GDPR_BUTTON_LOCATOR));
            _gdprButton.Click();
        }

        public void GoToLoginPage()
        {
            _loginLink = Driver.FindElement(By.LinkText(LOGIN_LINK_LOCATOR));
            _loginLink.Click();
        }
    }
}
