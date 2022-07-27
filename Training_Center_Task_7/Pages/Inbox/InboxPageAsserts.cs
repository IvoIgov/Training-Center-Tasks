using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_7.Inbox
{
    public static class InboxPageAsserts
    {
        public static void AssertNumberOfEmailsInInbox(this InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckNumberOfEmailsInInbox());
        }

        public static void AssertEmailSender(this InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailSender());
        }

        public static void AssertEmailSubject(this InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailSubject());
        }

        public static void AssertEmailText(this InboxPage page, string text)
        {
            Assert.AreEqual(text, page.CheckReceivedEmailText());
        }
    }
}
