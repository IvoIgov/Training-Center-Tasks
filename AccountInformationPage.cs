using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class AccountInformationPage : BasePage
    {
        private IWebDriver _driver;
        public AccountInformationPage(IWebDriver driver) : base(driver)
        {
            _driver = base.Driver;
        }

        public IWebElement Password => _driver.FindElement(By.CssSelector("input[data-qa='password']"));
        public IWebElement FirstName => _driver.FindElement(By.CssSelector("input[data-qa='first_name']"));
        public IWebElement LastName => _driver.FindElement(By.CssSelector("input[data-qa='last_name']"));
        public IWebElement Address => _driver.FindElement(By.CssSelector("input[data-qa='address']"));
        public IWebElement Country => _driver.FindElement(By.CssSelector("select[data-qa='country']"));
        public IWebElement State => _driver.FindElement(By.CssSelector("input[data-qa='state']"));
        public IWebElement City => _driver.FindElement(By.CssSelector("input[data-qa='city']"));
        public IWebElement Zipcode => _driver.FindElement(By.CssSelector("input[data-qa='zipcode']"));
        public IWebElement MobileNumber => _driver.FindElement(By.CssSelector("input[data-qa='mobile_number']"));
        public IWebElement CreateAccount => _driver.FindElement(By.CssSelector("button[data-qa='create-account']"));


        public void CreateNewUser(string password, string firstName, string lastName, string address,
            string country, string state, string city, string zipcode, string mobileNumber)
        {

            Password.SendKeys(password);
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Address.SendKeys(address);

            SelectElement dropDown = new SelectElement(Country);
            dropDown.SelectByValue(country);

            State.SendKeys(state);
            City.SendKeys(city);
            Zipcode.SendKeys(zipcode);
            MobileNumber.SendKeys(mobileNumber);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public AccountCreatedPage ClickCreateAccountButton()
        {
            CreateAccount.Click();
            return new AccountCreatedPage(_driver);
        }
    }
}
