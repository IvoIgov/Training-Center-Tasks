using OpenQA.Selenium;

namespace Training_Center_Task_11.Pages
{
    public class LogInPage : BasePage
    {
        private IWebElement _logInButton;
        private IWebElement _usernameTextBox;
        private IWebElement _loginButtonDialog;
        private IWebElement _passwordTextBox;

        const string LOGIN_BUTTON_LOCATOR =
            "button[class='Button2 Button2_size_m Button2_view_orange Button2_weight_500 Button_3YGxEShvAi7lB8DLgdG3y8 PSHeader-NoLoginButton']";

        const string USERNAME_TEXT_BOX_LOCATOR = "passp-field-login";
        const string LOGIN_DIALOG_BUTTON_LOCATOR = "passp:sign-in";
        const string PASSWORD_TEXT_BOX_LOCATOR = "passp-field-passwd";

        public LogInPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public IWebElement LoginButton { get; set; }
        public IWebElement UsernameTextBox { get; set; }
        public IWebElement PasswordTextBox { get; set; }
        public IWebElement LoginButtonDialog { get; set; }

        public InboxPage Login(string username, string password)
        {
            ClickLogInButton();
            FillUsernameTextBox(username);
            LoginButtonClick();
            FillPasswordTextBox(password);
            LoginButtonClick();

            return new InboxPage(Driver);
        }

        public void ClickLogInButton()
        {
            _logInButton = Driver.FindElement(By.CssSelector(LOGIN_BUTTON_LOCATOR));
            _logInButton.Click();
        }

        public void FillUsernameTextBox(string username)
        {
            _usernameTextBox = Driver.FindElement(By.Id(USERNAME_TEXT_BOX_LOCATOR));
            _usernameTextBox.Click();
            _usernameTextBox.SendKeys(username);
        }

        public void LoginButtonClick()
        {
            _loginButtonDialog = Driver.FindElement(By.Id(LOGIN_DIALOG_BUTTON_LOCATOR));
            _loginButtonDialog.Click();
        }

        public void FillPasswordTextBox(string password)
        {
            _passwordTextBox = Driver.FindElement(By.Id(PASSWORD_TEXT_BOX_LOCATOR));
            _passwordTextBox.Click();
            _passwordTextBox.SendKeys(password);
        }

        public bool CheckLoginButtonPresent()
        {
            _logInButton = Driver.FindElement(By.CssSelector(LOGIN_BUTTON_LOCATOR));
            return _logInButton.Displayed;
        }
    }
}
