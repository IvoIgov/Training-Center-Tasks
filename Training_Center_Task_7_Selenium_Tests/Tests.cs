using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Training_Center_Task_7;
using Training_Center_Task_7.Inbox;
using Training_Center_Task_7.Models;
using Training_Center_Task_7.Pages.Home;

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


        [TestInitialize]
        public void Init()
        {
            //var options = new ChromeOptions();
            //options.BinaryLocation = @"C:\Program Files\Google\Chrome Beta\Application\chrome.exe";
            this.driver = new ChromeDriver(ConstantsTests.WebDriverPath);
            //this.driver = new ChromeDriver(options);

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

            _inboxPage.AssertNumberOfEmailsInInbox("1");
            _inboxPage.AssertEmailSender("testtester10@yahoo.com");
            _inboxPage.AssertEmailSubject(testData.EmailSubject);
            _inboxPage.AssertEmailText(testData.EmailText);

            _inboxPage.DeleteAllEmailsFromInbox();

            _inboxPage.AssertNumberOfEmailsInInbox("0");
        }
    }
}