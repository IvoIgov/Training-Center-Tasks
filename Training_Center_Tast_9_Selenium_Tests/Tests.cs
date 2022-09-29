using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Training_Center_Task_9;
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
        private InboxPage _inboxPage;


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
        public void SendEmailCheckReceived()
        {
            var testName = @"SendEmailCheckReceived";

            JsonDataPattern testData = AccessJsonData.GetTestData(testName);

            _inboxPage = _loginPage.Login(testData.User1Username, testData.User1Password);
            _inboxPage.ComposeEmailAndSend(testData.EmailTo, testData.EmailSubject, testData.EmailText);
            _homePage = _inboxPage.LogOut();
            _loginPage = _homePage.NavigateToLoginPage();
            _inboxPage = _loginPage.Login(testData.User2Username, testData.User2Password);
            NUnit.Framework.Assert.AreEqual("1", _inboxPage.CheckNumberOfEmailsInInbox());
            NUnit.Framework.Assert.AreEqual(testData.EmailFrom, _inboxPage.CheckReceivedEmailSender());
            NUnit.Framework.Assert.AreEqual(testData.EmailSubject, _inboxPage.CheckReceivedEmailSubject());
            NUnit.Framework.Assert.AreEqual(testData.EmailText, _inboxPage.CheckReceivedEmailText());

            _inboxPage.DeleteAllEmailsFromInbox();
            NUnit.Framework.Assert.AreEqual("0", _inboxPage.CheckNumberOfEmailsInInbox());
        }
    }
}