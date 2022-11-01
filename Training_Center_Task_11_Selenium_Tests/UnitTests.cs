using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center_Task_11.Pages;

namespace Training_Center_Task_11_Selenium_Tests
{
    public class UnitTests
    {
        public void AssertLogInButtonDisplayed(LogInPage page)
        {
            Assert.AreEqual(true, page.CheckLoginButtonPresent());
        }
        public void AssertComposeButtonDisplayed(InboxPage page)
        {
            Assert.AreEqual(true, page.CheckComposeButtonPresent());
        }
        public void AssertUsernameCorrect(InboxPage page, string username)
        {
            Assert.AreEqual(username, page.CheckUsernameTextCorrect());
        }
    }
}
