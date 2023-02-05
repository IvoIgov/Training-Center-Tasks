using OpenQA.Selenium;

namespace Training_Center_Task_15.Pages
{
    public class Navigation : BasePage
    {
        private IWebDriver _driver;

        public Navigation(IWebDriver driver) : base(driver)
        {
            _driver = Driver;
        }

        public IWebElement SignUpLoginLink => _driver.FindElement(By.CssSelector("a[href='/login']"));
        public IWebElement LogoutLink => _driver.FindElement(By.CssSelector("a[href='/logout']"));
        public IWebElement DeleteAccountLink => _driver.FindElement(By.CssSelector("a[href='/delete_account']"));
        public IWebElement ProductsPageLink => _driver.FindElement(By.CssSelector("a[href='/products']"));

        public LoginPage ClickSignUpLoginLink()
        {
            SignUpLoginLink.Click();
            return new LoginPage(_driver);
        }

        public ProductsPage ClickProductsPageLink()
        {
            ProductsPageLink.Click();
            return new ProductsPage(_driver);
        }

        public AccountCreatedPage ClickDeleteAccountLink()
        {
            DeleteAccountLink.Click();
            return new AccountCreatedPage(_driver);
        }

        public LoginPage ClickLogoutLink()
        {
            LogoutLink.Click();
            return new LoginPage(_driver);
        }
    }
}
