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
        private IWebDriver _driver;

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
        [TestCase("1234")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.normal)]
        public void VerifyUserCannotLoginInvalidPassword(string password)
        {
            var homePage = new HomePage(_driver);
            var navigation = new Navigation(_driver);
            var loginPage = navigation.ClickSignUpLoginLink();

            var reader = new GetConsumerSettings();
            var primaryConsumerInfo = reader.GetPrimaryConsumerFileData();

            loginPage.LoginExistingUser(primaryConsumerInfo.Email, password);
            homePage = loginPage.ClickLoginButton();

            Assert.That(homePage.EmailOrPasswordIncorrectMessage.Text, Is.EqualTo("Your email or password is incorrect!"));
        }

        [Test(Author = "Ivo Igov", Description = "Fifth test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.minor)]
        public void VerifyUserCanDeleteAccount()
        {
            NewConsumer newConsumerInfo = new NewConsumer();
            var newConsumer = newConsumerInfo.GenerateNewConsumer();

            var navigation = new Navigation(_driver);
            var loginPage = navigation.ClickSignUpLoginLink();

            loginPage.SignupNewUser(newConsumer.Username, newConsumer.Email);
            var accountInformationPage = loginPage.ClickSignupButton();
            accountInformationPage.CreateNewUser(newConsumer.Password, newConsumer.FirstName,
                newConsumer.LastName, newConsumer.Address, newConsumer.Country, newConsumer.State,
                newConsumer.City, newConsumer.Zipcode, newConsumer.MobileNumber);
            var accountCreatedPage = accountInformationPage.ClickCreateAccountButton();
            RefreshPage();
            accountCreatedPage.ClickContinueButton();
            RefreshPage();
            accountCreatedPage.ClickContinueButton();
            RefreshPage();
            accountCreatedPage = navigation.ClickDeleteAccountLink();

            Assert.That(accountCreatedPage.AccountDeletedMessage.Text, Is.EqualTo("ACCOUNT DELETED!"));
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
