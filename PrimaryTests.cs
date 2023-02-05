using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using Training_Center_Task_15.Pages;

namespace Training_Center_Task_15
{
    [AllureNUnit]
    [AllureParentSuite("Root Suite")]
    public class PrimaryTests
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

        [Test(Author = "Ivo Igov", Description = "First test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.critical)]
        public void VerifyUserCanCreateAccount()
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

            Assert.That(accountCreatedPage.AccountCreatedMessage.Text, Is.EqualTo("ACCOUNT CREATED!"));
            Assert.IsTrue(accountCreatedPage.ContinueButton.Displayed);
        }

        [Test(Author = "Ivo Igov", Description = "Second test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.critical)]
        public void VerifyUserCanLogin()
        {
            var navigation = new Navigation(_driver);
            var loginPage = navigation.ClickSignUpLoginLink();

            var reader = new GetConsumerSettings();
            var primaryConsumerInfo = reader.GetPrimaryConsumerFileData();

            loginPage.LoginExistingUser(primaryConsumerInfo.Email, primaryConsumerInfo.Password);
            loginPage.ClickLoginButton();

            Assert.IsTrue(navigation.LogoutLink.Displayed);
        }

        [Test(Author = "Ivo Igov", Description = "Third test")]
        [TestCase(3)]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.normal)]
        public void VerifyUserCanPutProductsInCart(int numberofProductsToAddToCart)
        {
            var navigation = new Navigation(_driver);
            var loginPage = navigation.ClickSignUpLoginLink();

            var reader = new GetConsumerSettings();
            var primaryConsumerInfo = reader.GetPrimaryConsumerFileData();

            loginPage.LoginExistingUser(primaryConsumerInfo.Email, primaryConsumerInfo.Password);
            var homePage = loginPage.ClickLoginButton();

            var productsPage = navigation.ClickProductsPageLink();
            RefreshPage();
            productsPage.ScrollToFirstProducts();

            productsPage.AddMultipleProductsToCart(numberofProductsToAddToCart);
            var cartPage = productsPage.ClickCartLink();

            List<string> products = cartPage.GetProductsFromCart();
            Assert.That(products[0], Is.EqualTo("https://www.automationexercise.com/get_product_picture/1"));
            Assert.That(products[1], Is.EqualTo("https://www.automationexercise.com/get_product_picture/2"));
            Assert.That(products[2], Is.EqualTo("https://www.automationexercise.com/get_product_picture/3"));
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