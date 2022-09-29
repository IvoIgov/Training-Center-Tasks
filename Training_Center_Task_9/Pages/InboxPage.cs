using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_9.Pages
{
    public class InboxPage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;
        private IWebElement _accountMenu;


        public InboxPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            _accountMenu = _driver.FindElement(By.Id("ybarAccountMenu"), WebDriverWaitTime);
        }


        //public string CheckNumberOfEmailsInInbox()
        //{
        //    _numberOfEmailsInInbox = _driver.FindElement(By.CssSelector("a[data-test-total-count='compose-send-button']"), WebDriverWaitTime);

        //    return _numberOfEmailsInInbox.Text;
        //}
    }
}
