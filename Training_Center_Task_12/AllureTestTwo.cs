using NUnit.Allure.Attributes;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Allure.Commons;

namespace Training_Center_Task_12
{
    [AllureSuite("Tests - Advanced")]
    public class AllureTestTwo : BaseTest
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [Test(Author = "Author Two", Description = "Advanced test")]
        [Category("Category Two")]
        [AllureSeverity(SeverityLevel.minor)]
        public void AlertTestJavaScriptAlertBoxNameEnteredCorrectly()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click for Prompt Box" button
            IWebElement ClickForPromptBoxButton = _driver.FindElement(By.CssSelector("button[onclick='myPromptFunction()']"));
            ClickForPromptBoxButton.Click();

            //Enter the name in alert and click OK
            _driver.SwitchTo().Alert().SendKeys("Ivo");
            _driver.SwitchTo().Alert().Accept();

            IWebElement message = _driver.FindElement(By.Id("prompt-demo"));

            Assert.That("You have entered 'Ivo' !", Is.EqualTo(message.Text));
        }

        [Test]
        [Description("Advanced test with allure tags")]
        [AllureOwner("Author Two")]
        [AllureTag("Category Two")]
        [AllureSeverity(SeverityLevel.critical)]
        public void WaitForUser()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");

            //Click "Get New User" button and get photo URL of first user
            IWebElement getNewUserButton = _driver.FindElement(By.Id("save"));
            getNewUserButton.Click();

            IWebElement userPictureFirstUser = _driver.FindElement(By.CssSelector("img[src^='https://randomuser.me/api/portraits/']"));
            string urlFirstUser = userPictureFirstUser.GetAttribute("src");

            //Click Get New User button to load a new user
            getNewUserButton.Click();

            //Verify "loading..." message is displayed
            IWebElement loadingMessage = _driver.FindElement(By.Id("loading"));
            Assert.AreEqual(true, loadingMessage.Displayed);

            //Verify that after waiting a new user is displayed. Compare the URLs of first and second user pictures - they should be different.
            bool getNserButtonDisplayed = getNewUserButton.Displayed;
            IWebElement userPictureSecondUser = _driver.FindElement(By.CssSelector("img[src^='https://randomuser.me/api/portraits/']"));
            string urlSecondUser = userPictureSecondUser.GetAttribute("src");

            Assert.That(true, Is.EqualTo(getNserButtonDisplayed));
            Assert.That(urlFirstUser, Is.Not.EqualTo(urlSecondUser));
        }
    }
}
