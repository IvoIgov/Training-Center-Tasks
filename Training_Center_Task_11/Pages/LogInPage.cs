using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_11.Pages
{
    public class LogInPage : MainPage
    {
        private IWebDriver _driver;

        private IWebElement _logInButton;

        const string LOGIN_BUTTON_LOCATOR = 
            "button[class='Button2 Button2_size_m Button2_view_action Button2_weight_500 Button_Vd8eu21iIVyRdyjGPVfYF PSHeader-NoLoginButton']";

        public LogInPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLogInButton()
        {
            _logInButton = _driver.FindElement(By.CssSelector(LOGIN_BUTTON_LOCATOR), Constants.WebDriverWaitTime));
            _logInButton.Click();
        }
    }
}
