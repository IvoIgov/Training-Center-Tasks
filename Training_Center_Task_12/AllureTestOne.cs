using Allure.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Training_Center_Task_12
{
    [AllureSuite("Tests - Simple")]
    public class AllureTestOne : BaseTest
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

        [Test(Author = "Author One", Description = "Simple test")]
        [Category("Category One")]
        [AllureSeverity(SeverityLevel.minor)]

        public void AlertTestJavaScriptConfirmBoxVerifyAlertText()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

            //Pick alert text
            string alertText = _driver.SwitchTo().Alert().Text;

            Assert.That("Press a button!", Is.EqualTo(alertText));
        }

        [Test]
        [Description("Simple test with allure tags")]
        [AllureOwner("Author One")]
        [AllureTag("Category One")]
        [AllureSeverity(SeverityLevel.critical)]
        public void AlertTestJavaScriptConfirmBoxVerifyAlertClickedOK()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

            //Cliok OK on alert
            _driver.SwitchTo().Alert().Accept();

            IWebElement alertClickedOk = _driver.FindElement(By.Id("confirm-demo"));

            Assert.That("You pressed OK!", Is.EqualTo(alertClickedOk.Text));
        }
    }
}
