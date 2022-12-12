using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;

        private IWebElement _gdprButton;
        private IWebElement _loginLink;

        const string GDPR_BUTTON_LOCATOR = "button[data-text='Accept all']";
        const string LOGIN_LINK_LOCATOR = "Log in";
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement GDPRButton { get; set; }
        public IWebElement LoginLink { get; set; }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            GoToLoginPage();
            return new LogInPage(_driver);
        }

        public void AcceptGRPR()
        {
            _gdprButton = _driver.FindElement(By.CssSelector(GDPR_BUTTON_LOCATOR));
            _gdprButton.Click();
        }

        public void GoToLoginPage()
        {
            _loginLink = _driver.FindElement(By.LinkText(LOGIN_LINK_LOCATOR));
            _loginLink.Click();
        }
    }
}
