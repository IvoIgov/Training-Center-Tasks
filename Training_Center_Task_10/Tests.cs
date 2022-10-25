using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Debugger;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Xml.Linq;

namespace Training_Center_Task_10
{
    [TestClass]
    public class Tests
    {
        public IWebDriver _driver;
        [TestInitialize]
        public void Init()
        {
            this._driver = new FirefoxDriver();

            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        [DataTestMethod]
        [DataRow("testtester10", "t3st3rt3st10", "Test")]
        [DataRow("testtester200", "t3st3rt3st200", "Tester")]
        [Description("Tasks 1 - 4")]

        [TestMethod]
        public void Login(string username, string password, string name)
        {
            _driver.Navigate().GoToUrl("https://mail.yahoo.com/");

            //Fill in username
            IWebElement usernameTextbox = _driver.FindElement(By.Id("login-username"), 10);
            usernameTextbox.SendKeys(username);

            //Click LogIn button
            IWebElement loginButtonUsername = _driver.FindElement(By.CssSelector("input[id='login-signin']"), 10);
            loginButtonUsername.Click();

            //Fill in password
            IWebElement passwordTextbox = _driver.FindElement(By.Id("login-passwd"), 10);
            passwordTextbox.Click();
            passwordTextbox.SendKeys(password);

            //Click LogIn button
            IWebElement loginButtonPassword = _driver.FindElement(By.CssSelector("button[id='login-signin']"), 10);
            loginButtonPassword.Click();

            IWebElement usernameText = _driver.FindElement(By.CssSelector("span[role='presentation']"), 10);

            Assert.AreEqual(name, usernameText.Text);
        }

        [Description("Task 5")]
        [TestMethod]
        public void MultiselectTest()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");

            IWebElement multiselectMenu = _driver.FindElement(By.Id("multi-select"));
            SelectElement selections = new SelectElement(multiselectMenu);

            //Select three options from multiselect menu
            selections.SelectByText("California");
            selections.SelectByText("Ohio");
            selections.SelectByText("Texas");
            
            bool californiaSelected = _driver.FindElement(By.CssSelector("option[value='California']")).Selected;
            bool ohioSelected = _driver.FindElement(By.CssSelector("option[value='Ohio']")).Selected;
            bool texasSelected = _driver.FindElement(By.CssSelector("option[value='Texas']")).Selected;
            
            Assert.AreEqual(true, californiaSelected);
            Assert.AreEqual(true, ohioSelected);
            Assert.AreEqual(true, texasSelected);

            _driver.Wait(3000);
        }

        [Description("Task 6")]
        [TestMethod]
        public void AlertTestJavaScriptConfirmBoxVerifyAlertText()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

            _driver.Wait(2000);

            //Pick alert text
            string alertText = _driver.SwitchTo().Alert().Text;

            Assert.AreEqual("Press a button!", alertText);
        }

        [Description("Task 6")]
        [TestMethod]
        public void AlertTestJavaScriptConfirmBoxVerifyAlertClickedOK()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

            _driver.Wait(2000);

            //Cliok OK on alert
            _driver.SwitchTo().Alert().Accept();

            IWebElement alertClickedOk = _driver.FindElement(By.Id("confirm-demo"), 5);

            Assert.AreEqual("You pressed OK!", alertClickedOk.Text);
        }

        [Description("Task 6")]
        [TestMethod]
        public void AlertTestJavaScriptAlertBoxNameEnteredCorrectly()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click for Prompt Box" button
            IWebElement ClickForPromptBoxButton = _driver.FindElement(By.CssSelector("button[onclick='myPromptFunction()']"));
            ClickForPromptBoxButton.Click();

            _driver.Wait(2000);

            //Enter the name in alert and click OK
            _driver.SwitchTo().Alert().SendKeys("Ivo");
            _driver.SwitchTo().Alert().Accept();

            IWebElement message = _driver.FindElement(By.Id("prompt-demo"), 5);

            Assert.AreEqual("You have entered 'Ivo' !", message.Text);
        }
    }
}