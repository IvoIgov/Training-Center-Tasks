using OpenQA.Selenium;
using Training_Center_Task_11.Pages;
using Training_Center_Task_11;
using OpenQA.Selenium.Chrome;
using Training_Center_Task_11.Models;

namespace Training_Center_Task_11_Selenium_Tests
{
    [TestClass]
    public class Tests
    {
        public IWebDriver driver;
        private MainPage _mainPage;
        private HomePage _homePage;
        private LogInPage _loginPage;
        private InboxPage _inboxPage;
        private UnitTests _unitTests = new UnitTests();

        [TestInitialize]
        public void Init()
        {
            this.driver = new ChromeDriver(ConstantsTests.WebDriverPath);

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
        public void Login()
        {
            var testName = @"Login";

            JsonDataPattern testData = AccessJsonData.GetTestData(testName);

            _inboxPage = _loginPage.Login(testData.UserUsername, testData.UserPassword);

            _unitTests.AssertComposeButtonDisplayed(_inboxPage);
            _unitTests.AssertUsernameCorrect(_inboxPage, "bignevx");
        }

        [TestMethod]
        public void Logout()
        {
            var testName = @"Logout";

            JsonDataPattern testData = AccessJsonData.GetTestData(testName);

            _inboxPage = _loginPage.Login(testData.UserUsername, testData.UserPassword);
            _loginPage = _inboxPage.Logout();

            _unitTests.AssertLogInButtonDisplayed(_loginPage);
        }
    }
}