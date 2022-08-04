using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Training_Center_Task_7;
using Training_Center_Task_7.Models;
using Training_Center_Task_7.Pages;

namespace Training_Center_Task_7_Selenium_Tests
{
    [TestClass]
    public class Tests
    {
        public IWebDriver driver;
        private MainPage _mainPage;
        private HomePage _homePage;
        private LogInPage _loginPage;
        private InboxPage _inboxPage;
        private UnitTests _unitTests;



        [TestInitialize]
        public void Init()
        {
            //this.driver = new ChromeDriver(ConstantsTests.WebDriverPath);
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
        public void SendEmailCheckReceived()
        {
            var testName = @"SendEmailCheckReceived";

            JsonDataPattern testData = AccessJsonData.GetTestData(testName);
            
            _inboxPage = _loginPage.Login(testData.User1Username, testData.User1Password);
            _inboxPage.ComposeEmailAndSend(testData.EmailTo, testData.EmailSubject, testData.EmailText);
            _homePage = _inboxPage.LogOut();
            _loginPage = _homePage.NavigateToLoginPage();
            _inboxPage = _loginPage.Login(testData.User2Username, testData.User2Password);

            _unitTests.AssertNumberOfEmailsInInbox(_inboxPage, "Входящи\r\n1");
            _unitTests.AssertEmailSender(_inboxPage, "Test Tester");
            _unitTests.AssertEmailSubject(_inboxPage, testData.EmailSubject);
            _unitTests.AssertEmailText(_inboxPage, testData.EmailText);

            _inboxPage.DeleteAllEmailsFromInbox();

            _unitTests.AssertNumberOfEmailsInInbox(_inboxPage, "Входящи");
        }
    }
}