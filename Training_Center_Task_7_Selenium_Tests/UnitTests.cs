using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center_Task_7.Inbox;

namespace Training_Center_Task_7_Selenium_Tests
{
    public class UnitTests
    {
        public void AssertNumberOfEmailsInInbox(InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckNumberOfEmailsInInbox());
        }
        public void AssertEmailSender(InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailSender());
        }

        public void AssertEmailSubject(InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailSubject());
        }

        public void AssertEmailText(InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailText());
        }
    }
}
