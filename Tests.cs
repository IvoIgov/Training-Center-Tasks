using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace Training_Center_Task_15
{
    public class Tests
    {
        protected string _url = @"https://www.automationexercise.com/";

        protected string _newUserBaseUsername = "TestUser";
        protected string _username = "MyUser";
        protected string _email = "myuser@email.com";
        protected string _password = "123";
        protected string _domain = "@email.com";

        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private AccountInformationPage _accountInformationPage;
        private AccountCreatedPage _accountCreatedPage;
        private ProductsPage _productsPage;
        private CartPage _cartPage;

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
            CreateNewUser();

            Assert.That(_accountCreatedPage.AccountCreatedMessage.Text, Is.EqualTo("ACCOUNT CREATED!"));
            Assert.IsTrue(_accountCreatedPage.ContinueButton.Displayed);
        }

        [Test]
        public void VerifyUserCanLogin()
        {
            _homePage = new HomePage(_driver);
            _loginPage = _homePage.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            Assert.IsTrue(_homePage.LogoutLink.Displayed);
        }

        [Test]
        public void VerifyAbilityAddToCart()
        {
            int _numberofProductsToAddToCart = 3;

            _homePage = new HomePage(_driver);
            _loginPage = _homePage.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            _productsPage = _homePage.ClickProductsPageLink();
            _driver.Navigate().Refresh();
            _productsPage.ScrollToFirstProducts();
            
            _productsPage.AddMultipleProductsToCart(_numberofProductsToAddToCart);
            _cartPage = _productsPage.ClickCartLink();

            List<string> products = _cartPage.GetProductsFromCart();
            Assert.That(products[0], Is.EqualTo("https://www.automationexercise.com/get_product_picture/1"));
            Assert.That(products[1], Is.EqualTo("https://www.automationexercise.com/get_product_picture/2"));
            Assert.That(products[2], Is.EqualTo("https://www.automationexercise.com/get_product_picture/3"));
        }

        [Test]
        public void VerifyUserCannotLoginInvalidPassword()
        {
            _password = "1234";

            _homePage = new HomePage(_driver);
            _loginPage = _homePage.ClickSignUpLoginLink();

            _loginPage.LoginExistingUser(_email, _password);
            _homePage = _loginPage.ClickLoginButton();

            Assert.That(_homePage.EmailOrPasswordIncorrectMessage.Text, Is.EqualTo("Your email or password is incorrect!"));
        }

        public void CreateNewUser()
        {
            string dateTimeNow = DateTime.Now.ToString();
            string newUserUsername = this._newUserBaseUsername + dateTimeNow;
            string newUserEmail = newUserUsername + _domain;
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

            _loginPage.SignupNewUser(newUserUsername, newUserEmail);
            _accountInformationPage = _loginPage.ClickSignupButton();

            _accountInformationPage.CreateNewUser(_password, firstName, lastName, address, country, state, city, zipcode, mobileNumber);
            _accountCreatedPage = _accountInformationPage.ClickCreateAccountButton();
        }
    }
}