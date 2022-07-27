using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center_Task_7.Pages.Home;

namespace Training_Center_Task_7.Inbox
{
    public class InboxPage : MainPage
    {

        private IWebDriver _driver;
        private const int WebDriverWaitTime = 10;
        private IWebElement _composeEmailButton;
        private IWebElement _composeEmailToTextBox;
        private IWebElement _composeEmailSubjectTextBox;
        private IWebElement _composeEmailContentTextBox;
        private IWebElement _sendEmailButton;
        private IWebElement _accountMenu;
        private IWebElement _logoutButton;
        private IWebElement _signOutConfirmButton;
        private IWebElement _numberOfEmailsInInbox;
        private IWebElement _emailSenderField;
        private IWebElement _emailSubjectField;
        private IWebElement _emailTextField;
        private IWebElement _selectAllEmailsInInboxCheckbox;
        private IWebElement _deleteAllEmailsInInboxButton;


        public InboxPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            _composeEmailButton = _driver.FindElement(By.CssSelector("a[data-test-id='compose-button']"), WebDriverWaitTime);
            _accountMenu = _driver.FindElement(By.Id("ybarAccountMenu"), WebDriverWaitTime);
        }

        public void StartEmail()
        {
            _composeEmailButton.Click();
        }

        public void ComposeEmailAndSend(string emailTo, string emailSubject, string emailText)
        {
            StartEmail();
            _composeEmailToTextBox = _driver.FindElement(By.CssSelector("div[data-test-id='compose-header-field-to']"), WebDriverWaitTime);
            _composeEmailToTextBox.Click();
            _composeEmailToTextBox.SendKeys(emailTo);

            _composeEmailSubjectTextBox = _driver.FindElement(By.CssSelector("input[data-test-id='compose-subject']"), WebDriverWaitTime);
            _composeEmailSubjectTextBox.Click();
            _composeEmailSubjectTextBox.SendKeys(emailSubject);

            _composeEmailContentTextBox = _driver.FindElement(By.CssSelector("div[data-test-id='rte']"), WebDriverWaitTime);
            _composeEmailContentTextBox.Click();
            _composeEmailContentTextBox.SendKeys(emailText);

            _sendEmailButton = _driver.FindElement(By.CssSelector("button[data-test-id='compose-send-button']"), WebDriverWaitTime);
            _sendEmailButton.Click();
        }

        public HomePage LogOut()
        {
            _accountMenu.Click();
            _logoutButton = _driver.FindElement(By.Id("profile-signout-link"));
            _logoutButton.Click();
            _signOutConfirmButton = _driver.FindElement(By.CssSelector("input[data-logout='yes']"), WebDriverWaitTime);
            _signOutConfirmButton.Click();

            return new HomePage(_driver);
        }

        public string CheckNumberOfEmailsInInbox()
        {
            _numberOfEmailsInInbox = _driver.FindElement(By.CssSelector("a[data-test-total-count='compose-send-button']"), WebDriverWaitTime);

            return _numberOfEmailsInInbox.Text;
        }

        public string CheckReceivedEmailSender()
        {
            _emailSenderField = _driver.FindElement(By.CssSelector("div[data-test-id='senders']"), WebDriverWaitTime);

            return _emailSenderField.Text;
        }

        public string CheckReceivedEmailSubject()
        {
            _emailSubjectField = _driver.FindElement(By.CssSelector("span[data-test-id='message-subject']"), WebDriverWaitTime);

            return _emailSubjectField.Text;
        }

        public string CheckReceivedEmailText()
        {
            _emailTextField = _driver.FindElement(By.CssSelector("span[data-test-id='snippet']"), WebDriverWaitTime);

            return _emailTextField.Text;
        }

        public void DeleteAllEmailsFromInbox()
        {
            _selectAllEmailsInInboxCheckbox = _driver.FindElement(By.CssSelector("button[data-test-id='checkbox']"), WebDriverWaitTime);
            _selectAllEmailsInInboxCheckbox.Click();

            _deleteAllEmailsInInboxButton = _driver.FindElement(By.CssSelector("button[data-test-id='toolbar-delete']"), WebDriverWaitTime);
            _deleteAllEmailsInInboxButton.Click();
        }
    }
}
