using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Debugger;
using OpenQA.Selenium.Firefox;

namespace Training_Center_Task_10
{
    [TestClass]
    public class Tests
    {
        public IWebDriver _driver;
        [TestInitialize]
        public void Init()
        {
            this._driver = new FirefoxDriver();

            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        [DataTestMethod]
        [DataRow("test.tester.10", "testertest10")]
        [TestMethod]
        public void Login(string username, string password)
        {
            _driver.Navigate().GoToUrl("https://mail.yandex.com/");

            IWebElement loginButton = _driver.FindElement(By.CssSelector("button[class='Button2 Button2_size_m Button2_view_action Button2_weight_500 Button_Vd8eu21iIVyRdyjGPVfYF PSHeader-NoLoginButton']"), 10);
            loginButton.Click();
        
        }
    }
}