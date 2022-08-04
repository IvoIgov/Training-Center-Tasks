using OpenQA.Selenium;

namespace Training_Center_Task_7.Pages
{
    public class LogInPage : MainPage
    {
        private IWebDriver _driver;

        private const int WebDriverWaitTime = 10;

        const string SIGNIN_LINK_LOCATOR = "Sign in";
        const string USERNAME_TEXT_BOX_LOCATOR = "login-username";
        const string STAY_SIGNED_IN_CHECKBOX_LOCATOR = "label[for='persistent']";
        const string NEXT_BUTTON_LOCATOR = "login-signin";
        const string PASSWORD_TEXT_BOX_LOCATOR = "login-passwd";
        const string DENY_ALL_PERSONALISED_STATS_BUTTON_LOCATOR = "mail-decline-all-1";
        const string CLOSE_PERSONALISED_STATS_BUTTON_LOCATOR = "button[class='btn primary done-button']";

        private IWebElement _signInLink;
        private IWebElement _usernameTextBox;
        private IWebElement _passwordTextBox;
        private IWebElement _staySignedInCheckbox;
        private IWebElement _nextButton;
        private IWebElement _denyAllPersonalisedStatsButton;
        private IWebElement _closePersonalisedStatsButton;


        public LogInPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public InboxPage Login(string username, string password)
        {
            _driver.Wait(3000);

            try
            {
                _signInLink = _driver.FindElement(By.LinkText(SIGNIN_LINK_LOCATOR), WebDriverWaitTime);
                _signInLink.Click();
            }
            catch (Exception)
            {
            }

            _usernameTextBox = _driver.FindElement(By.Id(USERNAME_TEXT_BOX_LOCATOR), WebDriverWaitTime);
            _usernameTextBox.Click();
            _usernameTextBox.SendKeys(username);

            _staySignedInCheckbox = _driver.FindElement(By.CssSelector(STAY_SIGNED_IN_CHECKBOX_LOCATOR), WebDriverWaitTime);
            _staySignedInCheckbox.Click();

            _nextButton = _driver.FindElement(By.Id(NEXT_BUTTON_LOCATOR), WebDriverWaitTime);
            _nextButton.Click();

            _passwordTextBox = _driver.FindElement(By.Id(PASSWORD_TEXT_BOX_LOCATOR), WebDriverWaitTime);
            _passwordTextBox.SendKeys(password);

            //_nextButton = _driver.FindElement(By.Id("login-signin"), WebDriverWaitTime);
            _nextButton.Click();

            try
            {
                _denyAllPersonalisedStatsButton = _driver.FindElement(By.Id(DENY_ALL_PERSONALISED_STATS_BUTTON_LOCATOR), WebDriverWaitTime);
                _denyAllPersonalisedStatsButton.Click();
                _closePersonalisedStatsButton = _driver.FindElement(By.CssSelector(CLOSE_PERSONALISED_STATS_BUTTON_LOCATOR), WebDriverWaitTime);
                _closePersonalisedStatsButton.Click();
            }
            catch (Exception)
            {
            }

            return new InboxPage(_driver);
        }
    }
}
