using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using Training_Center_Task_15.Pages;

namespace Training_Center_Task_15
{
    [AllureNUnit]
    [AllureParentSuite("Branch Suite")]
    public class SecondaryTests
    {
        protected string _url = TestBaseInfo.URL;

        protected string _username = TestBaseInfo.MainUserUsername;
        protected string _email = TestBaseInfo.MainUserEmail;
        protected string _password = TestBaseInfo.MainUserPassword;

        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private AccountInformationPage _accountInformationPage;
        private AccountCreatedPage _accountCreatedPage;
        private Navigation _navigation;

        [OneTimeSetUp]
        public void Init()
        {
            SetUpEnvironmentDriver.StartDriver();
            _driver = SetUpEnvironmentDriver.GetDriver();
        }

        [SetUp]
        public void StartTest()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [Test(Author = "Ivo Igov", Description = "Fourth test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.normal)]
        public void VerifyUserCannotLoginInvalidPassword()
        {
            _password = "1234";

            _homePage = new HomePage(_driver);
            _navigation = new Navigation(_driver);
            _loginPage = _navigation.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            Assert.That(_homePage.EmailOrPasswordIncorrectMessage.Text, Is.EqualTo("Your email or password is incorrect!"));
        }

        [Test(Author = "Ivo Igov", Description = "Fifth test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.minor)]
        public void VerifyUserCanDeleteAccount()
        {
            NewConsumerInfo newConsumerInfo = new NewConsumerInfo();

            _navigation = new Navigation(_driver);
            _loginPage = _navigation.ClickSignUpLoginLink();

            _loginPage.SignupNewUser(newConsumerInfo.Username, newConsumerInfo.Email);
            _accountInformationPage = _loginPage.ClickSignupButton();
            _accountInformationPage.CreateNewUser(newConsumerInfo.Password, newConsumerInfo.FirstName,
                newConsumerInfo.LastName, newConsumerInfo.Address, newConsumerInfo.Country, newConsumerInfo.State,
                newConsumerInfo.City, newConsumerInfo.Zipcode, newConsumerInfo.MobileNumber);
            _accountCreatedPage = _accountInformationPage.ClickCreateAccountButton();
            _accountCreatedPage.ClickContinueButton();
            RefreshPage();
            _accountCreatedPage.ClickContinueButton();
            RefreshPage();
            _accountCreatedPage = _navigation.ClickDeleteAccountLink();

            Assert.That(_accountCreatedPage.AccountDeletedMessage.Text, Is.EqualTo("ACCOUNT DELETED!"));
        }

        [TearDown]
        public void DeleteCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void DriverStop()
        {
            SetUpEnvironmentDriver.StopDriver();
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }
    }
}
