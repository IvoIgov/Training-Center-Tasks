using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_9.Pages
{
    public class HomePage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;
        private IWebElement _dgprButton;
        private IWebElement _signInButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void AcceptGRPR()
        {
            _dgprButton = _driver.FindElement(By.CssSelector("button[class='btn primary']"), WebDriverWaitTime);
            _dgprButton.Click();
        }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            _signInButton = _driver.FindElement(By.CssSelector("a[class='_yb_118j3']"), WebDriverWaitTime);
            _signInButton.Click();
            return new LogInPage(_driver);
        }
    }
}
