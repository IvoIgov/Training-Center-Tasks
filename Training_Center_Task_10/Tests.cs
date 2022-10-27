using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Debugger;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
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

        [Description("Task 7")]
        [TestMethod]
        public void WaitForUser()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");

            //Click "Get New User" button
            IWebElement getNewUserButton = _driver.FindElement(By.Id("save"), 5);
            getNewUserButton.Click();

            //Verify "loading..." message is displayed
            IWebElement loadingMessage = _driver.FindElement(By.Id("loading"));
            Assert.AreEqual(true, loadingMessage.Displayed);

            //Verify that after 3 seconds of waiting a new user is displayed
            _driver.Wait(3000);
            Assert.AreEqual(true, getNewUserButton.Displayed);
        }

        [Description("Task 8")]
        [TestMethod]
        public void RefreshWhenDownloadSizeBiggerThan50()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html");

            //Click "Download" button
            IWebElement downloadButton = _driver.FindElement(By.Id("cricle-btn"), 5);
            downloadButton.Click();
            _driver.Wait(2000);

            //Track download progress
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            while (true)
            {
                IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.CssSelector("div[class='percenttext']")));
                string digits = searchResult.Text.Remove(searchResult.Text.Length - 1);
                int percentage = int.Parse(digits);
                if (percentage >= 50)
                {
                    break;
                }
            }

            //Refresh page
            _driver.Navigate().Refresh();
        }

        [Description("Task 9")]
        [TestMethod]
        public void ReturnNamePositionOffice()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/table-sort-search-demo.html");

            //Select "10" from dropdown
            IWebElement showEntriesDropdown = _driver.FindElement(By.CssSelector("select[name='example_length']"), 10);
            SelectElement selections = new SelectElement(showEntriesDropdown);
            selections.SelectByValue("10");

            //Create a loop which gets all row values and puts them in a list
            List<EmployeeInfo> employees = new List<EmployeeInfo>();
            FillInListOfEmployees(employees);

            Assert.AreEqual("A. Cox", employees[0].Name);
            Assert.AreEqual("B. Greer", employees[1].Name);
            Assert.AreEqual("G. Joyce", employees[2].Name);
            Assert.AreEqual("G. Winters", employees[3].Name);
            Assert.AreEqual("H. Chandler", employees[4].Name);
            Assert.AreEqual("M. Silva", employees[5].Name);
            Assert.AreEqual("S. Burks", employees[6].Name);


        }

        public List<EmployeeInfo> FillInListOfEmployees(List<EmployeeInfo> employees)
        {
            int counter = 2;
            while (true)
            {
                IWebElement table = _driver.FindElement(By.Id("example"));
                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    List<string> userData = new List<string>();
                    var data = row.FindElements(By.TagName("td"));
                    if (data.Count != 0)
                    {
                        foreach (var cell in data)
                        {
                            userData.Add(cell.Text);
                        }
                    }
                    else
                    {
                        continue;
                    }

                    int age = int.Parse(userData[3]);
                    int salary = int.Parse(Regex.Replace(userData[5], "[^0-9]", ""));

                    //Check whether employee is more > 39 years old and his salary is less than or equals $200,000
                    //If both are true, add him to respective list.

                    if (age > 39 && salary <= 200000)
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();
                        employeeInfo.Name = userData[0];
                        employeeInfo.Position = userData[1];
                        employeeInfo.Office = userData[2];
                        employees.Add(employeeInfo);
                    }
                }

                //Check whether there is next page and if yes - click the page number
                try
                {
                    var nextButtonDisabled = _driver.FindElement(By.CssSelector("a[class='paginate_button next disabled']"));
                    if (nextButtonDisabled.Displayed)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {

                }

                //Click next page
                var pageIndex = _driver.FindElement(By.CssSelector($"a[data-dt-idx='{counter}']"), 5);
                pageIndex.Click();
                _driver.Wait(5000);

                counter++;
            }
            return employees;
        }
    }
}