using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        [DataTestMethod]
        //[DataRow("r0b3rt.sm1th", "R0b3rt!@", "r0b3rt.sm1th")]
        //[DataRow("test.tester.10", "testertest10", "Test")]
        [DataRow("bignevx", "Parolata007!", "bignevx")]
        [DataRow("bignevx", "Parolata007!", "bignevx")]
        [Description("Tasks 1 - 4")]

        [TestMethod]
        public void Login(string username, string password, string name)
        {
            _driver.Navigate().GoToUrl("https://mail.yandex.com/");

            //Click Accept button
            IWebElement acceptButton = _driver.FindElement(By.CssSelector("button[data-id='button-all']"));
            acceptButton.Click();

            //Click LogIn button
            IWebElement loginButton = _driver.FindElement(By.CssSelector
               ("button[class='Button2 Button2_size_m Button2_view_orange Button2_weight_500 Button_3YGxEShvAi7lB8DLgdG3y8 PSHeader-NoLoginButton']"));
            loginButton.Click();
            
            //Fill in username
            IWebElement usernameTextbox = _driver.FindElement(By.Id("passp-field-login"));
            usernameTextbox.SendKeys(username);

            //Click LogIn button
            IWebElement loginButtonUsername = _driver.FindElement(By.CssSelector("button[id='passp:sign-in']"));
            loginButtonUsername.Click();

            //Fill in password
            IWebElement passwordTextbox = _driver.FindElement(By.Id("passp-field-passwd"));
            passwordTextbox.Click();
            passwordTextbox.SendKeys(password);

            //Click LogIn button
            IWebElement loginButtonPassword = _driver.FindElement(By.CssSelector("button[id='passp:sign-in']"));
            loginButtonPassword.Click();

            //Check user's name
            IWebElement composeButton =
                _driver.FindElement(By.CssSelector("a[class='Button2 Button2_type_link Button2_view_action Button2_size_m Layout-m__compose--pTDsx qa-LeftColumn-ComposeButton ComposeButton-m__root--fP-o9']"));
            IWebElement usernameText = _driver.FindElement(By.CssSelector("span[class='user-account__name']"));

            Assert.AreEqual(name, usernameText.Text);
        }

        [Description("Task 5")]
        [TestMethod]
        public void MultiselectTest()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");

            IWebElement multiselectMenu = _driver.FindElement(By.Id("multi-select"));
            SelectElement selections = new SelectElement(multiselectMenu);
            int selectionsCount = multiselectMenu.FindElements(By.TagName("option")).Count;
            List<string> optionValues = new List<string>();

            foreach (var element in multiselectMenu.FindElements(By.TagName("option")))
            {
                string option = element.Text;
                optionValues.Add(option);
            }

            //Select three random options from multiselect menu. Verify options are not duplicated
            Random random = new Random();
            List<int> indexes = new List<int>();

            while (true)
            {
                int index = random.Next(selectionsCount);
                if(!indexes.Contains(index))
                {
                    indexes.Add(index);
                    if(indexes.Count == 3)
                    {
                        break;
                    }
                }
            }

            selections.SelectByIndex(indexes[0]);
            selections.SelectByIndex(indexes[1]);
            selections.SelectByIndex(indexes[2]);

            string firstSelected = optionValues[indexes[0]];
            string secondSelected = optionValues[indexes[1]];
            string thirdSelected = optionValues[indexes[2]];


            bool firstSelectedTrue = _driver.FindElement(By.CssSelector($"option[value='{firstSelected}']")).Selected;
            bool secondSelectedTrue = _driver.FindElement(By.CssSelector($"option[value='{secondSelected}']")).Selected;
            bool thirdSelectedTrue = _driver.FindElement(By.CssSelector($"option[value='{thirdSelected}']")).Selected;

            Assert.AreEqual(true, firstSelectedTrue);
            Assert.AreEqual(true, secondSelectedTrue);
            Assert.AreEqual(true, thirdSelectedTrue);
        }

        [Description("Task 6")]
        [TestMethod]
        public void AlertTestJavaScriptConfirmBoxVerifyAlertText()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

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

            //Cliok OK on alert
            _driver.SwitchTo().Alert().Accept();

            IWebElement alertClickedOk = _driver.FindElement(By.Id("confirm-demo"));

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

            //Enter the name in alert and click OK
            _driver.SwitchTo().Alert().SendKeys("Ivo");
            _driver.SwitchTo().Alert().Accept();

            IWebElement message = _driver.FindElement(By.Id("prompt-demo"));

            Assert.AreEqual("You have entered 'Ivo' !", message.Text);
        }

        [Description("Task 7")]
        [TestMethod]
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

            Assert.AreEqual(true, getNserButtonDisplayed);
            Assert.AreNotEqual(urlFirstUser, urlSecondUser);
        }

        [Description("Task 8")]
        [TestMethod]
        public void RefreshWhenDownloadSizeBiggerThan50()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html");

            //Click "Download" button
            IWebElement downloadButton = _driver.FindElement(By.Id("cricle-btn"));
            downloadButton.Click();

            //Track download progress
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(Exception));

            while (true)
            {
                IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.CssSelector("div[class='percenttext']")));
                int digits = int.Parse(Regex.Replace(searchResult.Text, "[^0-9]", ""));
                if (digits >= 50)
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
            string showEntries = "10";
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/table-sort-search-demo.html");

            //Select "10" from dropdown
            IWebElement showEntriesDropdown = _driver.FindElement(By.CssSelector("select[name='example_length']"));
            SelectElement selections = new SelectElement(showEntriesDropdown);
            selections.SelectByValue(showEntries);

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
            int ageToCompare = 39;
            int salaryToCompare = 200000;

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
                        int age = int.Parse(userData[3]);
                        int salary = int.Parse(Regex.Replace(userData[5], "[^0-9]", ""));

                        //Check whether employee is more > 39 years old and his salary is less than or equals $200,000
                        //If both are true, add him to respective list.

                        if (age > ageToCompare && salary <= salaryToCompare)
                        {
                            EmployeeInfo employeeInfo = new EmployeeInfo();
                            employeeInfo.Name = userData[0];
                            employeeInfo.Position = userData[1];
                            employeeInfo.Office = userData[2];
                            employees.Add(employeeInfo);
                        }
                    }
                }

                //Check whether there is next page and if yes - click the page number

                IWebElement nextButton = _driver.FindElement(By.Id("example_next"));
                string nextButtonAtrribute = nextButton.GetAttribute("class");
                if (nextButtonAtrribute == "paginate_button next disabled")
                {
                    break;
                }

                //Click next page
                var pageIndex = _driver.FindElement(By.CssSelector($"a[data-dt-idx='{counter}']"));
                pageIndex.Click();

                counter++;
            }
            return employees;
        }
    }
}