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

        protected string _username = TestBaseInfo.MainUserUsername;
        protected string _email = TestBaseInfo.MainUserEmail;
        protected string _password = TestBaseInfo.MainUserPassword;

        private IWebDriver _driver;
        private LoginPage _loginPage;
        private AccountInformationPage _accountInformationPage;
        private AccountCreatedPage _accountCreatedPage;
        private ProductsPage _productsPage;
        private CartPage _cartPage;
        private HomePage _homePage;
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

        [Test(Author = "Ivo Igov", Description = "First test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.critical)]
        public void VerifyUserCanCreateAccount()
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

            Assert.That(_accountCreatedPage.AccountCreatedMessage.Text, Is.EqualTo("ACCOUNT CREATED!"));
            Assert.IsTrue(_accountCreatedPage.ContinueButton.Displayed);
        }

        [Test(Author = "Ivo Igov", Description = "Second test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.critical)]
        public void VerifyUserCanLogin()
        {
            _navigation = new Navigation(_driver);
            _loginPage = _navigation.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            Assert.IsTrue(_navigation.LogoutLink.Displayed);
        }

        [Test(Author = "Ivo Igov", Description = "Third test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.normal)]
        public void VerifyUserCanPutProductsInCart()
        {
            int _numberofProductsToAddToCart = 3;

            _navigation = new Navigation(_driver);
            _loginPage = _navigation.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            _productsPage = _navigation.ClickProductsPageLink();
            RefreshPage();
            _productsPage.ScrollToFirstProducts();

            _productsPage.AddMultipleProductsToCart(_numberofProductsToAddToCart);
            _cartPage = _productsPage.ClickCartLink();

            List<string> products = _cartPage.GetProductsFromCart();
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