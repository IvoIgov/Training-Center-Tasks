using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Training_Center_Task_9;
using Training_Center_Task_9.Models;
using Training_Center_Task_9.Pages;

namespace Training_Center_Tast_9_Selenium_Tests
{
    [TestClass]
    public class Tests
    {
        public IWebDriver driver;
        private MainPage _mainPage;
        private HomePage _homePage;
        private LogInPage _loginPage;


        [TestInitialize]
        public void Init()
        {
            this.driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();
            _mainPage = new MainPage(driver);
            driver.Navigate().GoToUrl(_mainPage.URL);
            _homePage = new HomePage(driver);
            _loginPage = _homePage.NavigateToLoginPage();
        }

        [TestCleanup]
        public void DriverQuit()
        {
            driver.Quit();
        }

        [TestMethod]
        public void LoginValidCredentials()
        {
            var testName = @"LoginValidCredentials";

            JsonDataPattern testData = AccessJsonData.GetTestData(testName);

            _homePage = _loginPage.Login(testData.User1Username, testData.User1Password);

            Assert.AreEqual("Test", _homePage.CheckAccountName());
        }
    }
}