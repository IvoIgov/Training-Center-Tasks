using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Training_Center_Task_7.Pages.Home;

namespace Training_Center_Task_7.Inbox
{
    public class InboxPage : MainPage
    {

        private IWebDriver _driver;

        private const int WebDriverWaitTime = 10;

        const string COMPOSE_EMAIL_BUTTON_LOCATOR = "a[data-test-id='compose-button']";
        const string ACCOUNT_MENU_LOCATOR = "ybarAccountMenu";
        const string COMPOSE_EMAIL_TO_TEXT_BOX_LOCATOR = "message-to-field";
        const string COMPOSE_EMAIL_SUBJECT_TEXT_BOX_LOCATOR = "input[data-test-id='compose-subject']";
        const string COMPOSE_EMAIL_CONTENT_TEXT_BOX_LOCATOR = "div[data-test-id='rte']";
        const string SEND_EMAIL_BUTTON_LOCATOR = "button[data-test-id='compose-send-button']";
        const string LOGOUT_BUTTON_LOCATOR = "profile-signout-link";
        const string NUMBER_OF_EMAILS_IN_INBOX_LOCATOR = "a[data-test-id='folder-list-item']";
        const string EMAIL_SENDER_FIELD_LOCATOR = "div[data-test-id='senders']";
        const string EMAIL_SUBJECT_FIELD_LOCATOR = "span[data-test-id='message-subject']";
        const string EMAIL_TEXT_FIELD_LOCATOR = "div[data-test-id='snippet']";
        const string SELECT_ALL_EMAIL_IN_INBOX_CHECKBOX = "button[data-test-id='checkbox']";
        const string DELETE_ALL_EMAILS_IN_INBOX_BUTTON = "button[data-test-id='toolbar-delete']";

        private IWebElement _composeEmailButton;
        private IWebElement _composeEmailToTextBox;
        private IWebElement _composeEmailSubjectTextBox;
        private IWebElement _composeEmailContentTextBox;
        private IWebElement _sendEmailButton;
        private IWebElement _accountMenu;
        private IWebElement _logoutButton;
        private IWebElement _numberOfEmailsInInbox;
        private IWebElement _emailSenderField;
        private IWebElement _emailSubjectField;
        private IWebElement _emailTextField;
        private IWebElement _selectAllEmailsInInboxCheckbox;
        private IWebElement _deleteAllEmailsInInboxButton;


        public InboxPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            _composeEmailButton = _driver.FindElement(By.CssSelector(COMPOSE_EMAIL_BUTTON_LOCATOR), WebDriverWaitTime);
            _accountMenu = _driver.FindElement(By.Id(ACCOUNT_MENU_LOCATOR), WebDriverWaitTime);
        }

        public void StartEmail()
        {
            _composeEmailButton.Click();
        }

        public void ComposeEmailAndSend(string emailTo, string emailSubject, string emailText)
        {
            StartEmail();
            _composeEmailToTextBox = _driver.FindElement(By.Id(COMPOSE_EMAIL_TO_TEXT_BOX_LOCATOR), WebDriverWaitTime);
            _composeEmailToTextBox.Click();
            _composeEmailToTextBox.SendKeys(emailTo);

            _composeEmailSubjectTextBox = _driver.FindElement(By.CssSelector(COMPOSE_EMAIL_SUBJECT_TEXT_BOX_LOCATOR), WebDriverWaitTime);
            _composeEmailSubjectTextBox.Click();
            _composeEmailSubjectTextBox.SendKeys(emailSubject);

            _composeEmailContentTextBox = _driver.FindElement(By.CssSelector(COMPOSE_EMAIL_CONTENT_TEXT_BOX_LOCATOR), WebDriverWaitTime);
            _composeEmailContentTextBox.Click();
            _composeEmailContentTextBox.SendKeys(emailText);

            _sendEmailButton = _driver.FindElement(By.CssSelector(SEND_EMAIL_BUTTON_LOCATOR), WebDriverWaitTime);
            _sendEmailButton.Click();
        }

        public HomePage LogOut()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_accountMenu).Perform();
            _driver.Wait(2000);
            _logoutButton = _driver.FindElement(By.Id(LOGOUT_BUTTON_LOCATOR));
            _logoutButton.Click();

            return new HomePage(_driver);
        }

        public string CheckNumberOfEmailsInInbox()
        {
            _numberOfEmailsInInbox = _driver.FindElement(By.CssSelector(NUMBER_OF_EMAILS_IN_INBOX_LOCATOR), WebDriverWaitTime);

            return _numberOfEmailsInInbox.Text;
        }

        public string CheckReceivedEmailSender()
        {
            _emailSenderField = _driver.FindElement(By.CssSelector(EMAIL_SENDER_FIELD_LOCATOR), WebDriverWaitTime);

            return _emailSenderField.Text;
        }

        public string CheckReceivedEmailSubject()
        {
            _emailSubjectField = _driver.FindElement(By.CssSelector(EMAIL_SUBJECT_FIELD_LOCATOR), WebDriverWaitTime);

            return _emailSubjectField.Text;
        }

        public string CheckReceivedEmailText()
        {
            _emailTextField = _driver.FindElement(By.CssSelector(EMAIL_TEXT_FIELD_LOCATOR), WebDriverWaitTime);

            return _emailTextField.Text;
        }

        public void DeleteAllEmailsFromInbox()
        {
            _selectAllEmailsInInboxCheckbox = _driver.FindElement(By.CssSelector(SELECT_ALL_EMAIL_IN_INBOX_CHECKBOX), WebDriverWaitTime);
            _selectAllEmailsInInboxCheckbox.Click();

            _deleteAllEmailsInInboxButton = _driver.FindElement(By.CssSelector(DELETE_ALL_EMAILS_IN_INBOX_BUTTON), WebDriverWaitTime);
            _deleteAllEmailsInInboxButton.Click();
        }
    }
}
