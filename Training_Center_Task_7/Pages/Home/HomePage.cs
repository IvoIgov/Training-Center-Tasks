using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_7.Pages.Home
{
    public class HomePage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;
        private IWebElement _dgprButton;
        private IWebElement _mailButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void AcceptGRPR()
        {
            _dgprButton = _driver.FindElement(By.CssSelector("button[class='btn primary']"), WebDriverWaitTime);
            _dgprButton.Click();
        }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            _mailButton = _driver.FindElement(By.Id("ybarMailLink"), WebDriverWaitTime);
            _mailButton.Click();
            return new LogInPage(_driver);
        }
    }
}
