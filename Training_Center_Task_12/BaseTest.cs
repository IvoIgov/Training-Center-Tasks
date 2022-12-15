using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Training_Center_Task_12
{
    [AllureNUnit]
    [AllureParentSuite("Root Suite")]
    public class BaseTest
    {
        private IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                return this._driver;
            }
            set
            {
                this._driver = value;
            }
        }
    }
}
