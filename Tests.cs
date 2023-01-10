using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Training_Center_Task_15
{
    public class Tests
    {
        protected string _url = @"https://www.automationexercise.com/";

        protected string newUserBaseUsername = "TestUser";
        protected string username = "MyUser";
        protected string email = "myuser@email.com";
        protected string password = "123";
        protected string domain = "@email.com";

        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private AccountInformationPage _accountInformationPage;
        private AccountCreatedPage _accountCreatedPage;

        [SetUp]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-popup-blocking");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_url);
        }

        [TearDown]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        [Test]
        public void VerifyUserCanCreateAccount()
        {
            string dateTimeNow = DateTime.Now.ToString();
            string newUserUsername = this.newUserBaseUsername + dateTimeNow;
            string newUserEmail = newUserUsername + domain;
            newUserEmail = newUserEmail.Replace(" ", "");
            newUserEmail = newUserEmail.Replace(":", "");

            string firstName = newUserUsername + "_FN";
            string lastName = newUserUsername + "_LN";
            string address = "1 Main St.";
            string country = "United States";
            string state = "Nebraska";
            string city = "Omaha";
            string zipcode = "12345";
            string mobileNumber = "123456789";

            _homePage = new HomePage(_driver);
            _loginPage = _homePage.ClickSignUpLoginLink();

            _loginPage.NameTextBox.Click();
            _loginPage.NameTextBox.SendKeys(newUserUsername);

            _loginPage.EmailAddressTextBox.Click();
            _loginPage.EmailAddressTextBox.SendKeys(newUserEmail);
            _accountInformationPage = _loginPage.ClickSignupButton();

            _accountInformationPage.CreateNewUser(password, firstName, lastName, address, country, state, city, zipcode, mobileNumber);
            _accountCreatedPage = _accountInformationPage.ClickCreateAccountButton();

            Assert.That(_accountCreatedPage.AccountCreatedMessage.Text, Is.EqualTo("ACCOUNT CREATED!"));
            Assert.IsTrue(_accountCreatedPage.ContinueButton.Displayed);
        }
    }
}