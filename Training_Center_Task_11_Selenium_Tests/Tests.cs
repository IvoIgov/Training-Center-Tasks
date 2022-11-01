using OpenQA.Selenium;
using Training_Center_Task_11.Pages;
using Training_Center_Task_11;
using OpenQA.Selenium.Chrome;
using Training_Center_Task_11.Models;
using System.IO;

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

            TakeScreenshot();

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

        public void TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string currentDate = DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
            ss.SaveAsFile(@"C:\Users\IvoIgov\source\repos\Training_Center_Task_11\Screenshots" + String.Format("//Screenshot{0}.png", currentDate), ScreenshotImageFormat.Png);
        }
    }
}