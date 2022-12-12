using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class InboxPage : BasePage
    {
        private IWebElement _composeButton;
        private IWebElement _usernameLink;
        private IWebElement _logoutLink;

        const string COMPOSE_BUTTON_LOCATOR = "a[href='#compose']";
        const string USERNAME_LINK_LOCATOR = "span[class='user-account__name']";
        const string LOGOUT_LINK_LOCATOR = "a[aria-label='Log out']";

        public InboxPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public IWebElement ComposeButton { get; set; }
        public IWebElement UsernameLink { get; set; }
        public IWebElement LogoutLink { get; set; }

        public LogInPage Logout()
        {
            ClickUsernameLink();
            ClickLogoutLink();

            return new LogInPage(Driver);
        }

        public bool CheckComposeButtonPresent()
        {
            _composeButton = Driver.FindElement(By.CssSelector(COMPOSE_BUTTON_LOCATOR));
            return _composeButton.Displayed;
        }

        public string CheckUsernameTextCorrect()
        {
            _usernameLink = Driver.FindElement(By.CssSelector(USERNAME_LINK_LOCATOR));
            return _usernameLink.Text;
        }

        public void ClickUsernameLink()
        {
            _usernameLink = Driver.FindElement(By.CssSelector(USERNAME_LINK_LOCATOR));
            _usernameLink.Click();
        }

        public void ClickLogoutLink()
        {
            _logoutLink = Driver.FindElement(By.CssSelector(LOGOUT_LINK_LOCATOR));
            _logoutLink.Click();
        }
    }
}
