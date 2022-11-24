using OpenQA.Selenium;

namespace Training_Center_Task_9.Pages
{
    public class HomePage : MainPage
    {
        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;

        const string GDPR_BUTTON_LOCATOR = "button[class='btn primary']";
        const string SIGN_IN_BUTTON_LOCATOR = "a[class='_yb_118j3']";
        const string ACCOUNT_NAME_LOCATOR = "span[role='presentation']";


        private IWebElement _gdprButton;
        private IWebElement _signInButton;
        private IWebElement _accountName;


        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void AcceptGRPR()
        {
            try
            {
                _gdprButton = _driver.FindElement(By.CssSelector(GDPR_BUTTON_LOCATOR), WebDriverWaitTime);
                _gdprButton.Click();
            }
            catch (Exception)
            {
            }
        }

        public LogInPage NavigateToLoginPage()
        {
            AcceptGRPR();
            _signInButton = _driver.FindElement(By.CssSelector(SIGN_IN_BUTTON_LOCATOR), WebDriverWaitTime);
            _signInButton.Click();
            return new LogInPage(_driver);
        }

        public string CheckAccountName()
        {
            _accountName = _driver.FindElement(By.CssSelector(ACCOUNT_NAME_LOCATOR), WebDriverWaitTime);

            return _accountName.Text;
        }
    }
}
