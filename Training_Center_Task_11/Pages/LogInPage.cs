using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class LogInPage : MainPage
    {
        private IWebDriver _driver;

        private IWebElement _logInButton;
        private IWebElement _usernameTextBox;
        private IWebElement _loginButtonDialog;
        private IWebElement _passwordTextBox;

        const string LOGIN_BUTTON_LOCATOR = 
            "button[class='Button2 Button2_size_m Button2_view_action Button2_weight_500 Button_Vd8eu21iIVyRdyjGPVfYF PSHeader-NoLoginButton']";

        const string USERNAME_TEXT_BOX_LOCATOR = "passp-field-login";
        const string LOGIN_DIALOG_BUTTON_LOCATOR = "passp:sign-in";
        const string PASSWORD_TEXT_BOX_LOCATOR = "passp-field-passwd";

        public LogInPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _logInButton = _driver.FindElement(By.CssSelector(LOGIN_BUTTON_LOCATOR), Constants.WebDriverWaitTime);
        }

        public InboxPage Login(string username, string password)
        {
            ClickLogInButton();
            FillUsernameTextBox(username);
            LoginButtonClick();
            FillPasswordTextBox(password);
            LoginButtonClick();

            return new InboxPage(_driver);
        }

        public void ClickLogInButton()
        {
            _logInButton.Click();
        }

        public void FillUsernameTextBox(string username)
        {
            _usernameTextBox = _driver.FindElement(By.Id(USERNAME_TEXT_BOX_LOCATOR), Constants.WebDriverWaitTime);
            _usernameTextBox.Click();
            _usernameTextBox.SendKeys(username);
        }

        public void LoginButtonClick()
        {
            _loginButtonDialog = _driver.FindElement(By.Id(LOGIN_DIALOG_BUTTON_LOCATOR), Constants.WebDriverWaitTime);
            _loginButtonDialog.Click();
            _driver.Wait(7000);
        }

        public void FillPasswordTextBox(string password)
        {
            _passwordTextBox = _driver.FindElement(By.Id(PASSWORD_TEXT_BOX_LOCATOR), Constants.WebDriverWaitTime);
            _passwordTextBox.Click();
            _passwordTextBox.SendKeys(password);
        }

        public bool CheckLoginButtonPresent()
        {
            return _logInButton.Displayed;
        }
    }
}
