using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Training_Center_Task_14
{
    public class Tests
    {
        private RemoteWebDriver _driver;

        [SetUp]
        public void Init()
        {
            GetSettings settings = new GetSettings();
            var item = settings.GetItem();

            String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            String currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var browserOptions = SelectBrowserAndPlatform(item.browser);
            browserOptions.PlatformName = item.platformName;
            browserOptions.BrowserVersion = item.browserVersion;
            browserOptions.AddAdditionalOption("username", "Ivo_Igov");
            browserOptions.AddAdditionalOption("accessKey", "930c032e-9c3e-4ea4-841e-eab1aaba457e");

            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", "Platform Configurator Build " + currentDate);
            sauceOptions.Add("job", "Platform Configurator Job " + currentTime);
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://Ivo_Igov:930c032e-9c3e-4ea4-841e-eab1aaba457e@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            _driver = new RemoteWebDriver(uri, browserOptions);
            ((IJavaScriptExecutor)_driver).ExecuteScript($"sauce:job-name= {TestContext.CurrentContext.Test.MethodName}");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
        }

        private DriverOptions SelectBrowserAndPlatform(string browser)
        {
            DriverOptions option = null;

            switch (browser)
            {

                case "chrome":
                    option = new ChromeOptions();
                    break;
                case "edge":
                    option = new EdgeOptions();
                    break;
                case "firefox":
                    option = new FirefoxOptions();
                    break;
                default:
                    Console.WriteLine("default settings");
                    break;
            }

            return option;
        }

        [TearDown]
        public void DriverQuit()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)_driver).ExecuteScript(script);

            _driver?.Quit();
        }

        [Test]
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
                if (!indexes.Contains(index))
                {
                    indexes.Add(index);
                    if (indexes.Count == 3)
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

            Assert.That(firstSelectedTrue, Is.EqualTo(true));
            Assert.That(secondSelectedTrue, Is.EqualTo(true));
            Assert.That(thirdSelectedTrue, Is.EqualTo(true));
        }

        [Test]
        public void AlertTestJavaScriptConfirmBoxVerifyAlertText()
        {
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");

            //Click "Click me!" button
            IWebElement ClickMeButton = _driver.FindElement(By.CssSelector("button[onclick='myConfirmFunction()']"));
            ClickMeButton.Click();

            //Pick alert text
            string alertText = _driver.SwitchTo().Alert().Text;

            Assert.That(alertText, Is.EqualTo("Press a button!"));
        }
    }
}