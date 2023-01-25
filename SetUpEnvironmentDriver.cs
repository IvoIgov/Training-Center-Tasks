using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Training_Center_Task_15
{
    public class SetUpEnvironmentDriver
    {
        private static WebDriver _driver;

        public static WebDriver GetDriver()
        {
            if (_driver == null)
            {
                StartDriver();
            }
            return _driver;
        }
        private static void SetDriver(WebDriver value)
        {
            _driver = value;
        }

        public static void StartDriver()
        {
            //private Settings mySettings = SettingsReader.ReadSettings();
            var reader = new GetSettings();
            var getSettings = reader.GetConfigFileData();

            switch (getSettings.Environment.Trim().ToLower())
            {
                case ("local"):
                    SetLocalDriver(getSettings.Browser.Trim().ToLower());
                    break;
                //case ("selenoid"):
                //    SetRemoteDriver(getSettings.Environment.Trim().ToLower(), getSettings.Browser.Trim().ToLower());
                //    break;
                case ("saucelabs"):
                    SetRemoteDriver(getSettings.Environment.Trim().ToLower(), getSettings.Browser.Trim().ToLower());
                    break;
                default:
                    throw new ArgumentException("You need to set a valid settings.");
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        private static void SetLocalDriver(string getBrowser)
        {
            switch (getBrowser)
            {
                case ("chrome"):
                    SetDriver(new ChromeDriver());
                    break;
                case ("firefox"):
                    SetDriver(new FirefoxDriver());
                    break;
                default:
                    throw new ArgumentException("You need to set a valid browser type.");
            }
        }

        private static void SetRemoteDriver(string environment, string getBrowser)
        {
            DriverOptions options = null;
            Uri sauceUrl = null;

            switch (getBrowser)
            {
                case ("chrome"):
                    options = new ChromeOptions();
                    break;
                case ("firefox"):
                    options = new FirefoxOptions();
                    break;
                default:
                    throw new ArgumentException("Set a valid browser type.");
            }

            switch (environment)
            {
                //case ("selenoid"):
                //    sauceUrl = new Uri("http://localhost:4444/wd/hub");
                //    SetDriver(new RemoteWebDriver(sauceUrl, options));
                //    break;
                case ("saucelabs"):
                    String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    String currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    var browserOptions = options;
                    browserOptions.PlatformName = "Windows 10";
                    browserOptions.BrowserVersion = null;

                    var sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("build", "Platform Configurator Build " + currentDate);
                    sauceOptions.Add("job", "Platform Configurator Job " + currentTime);
                    sauceOptions.Add("username", Environment.GetEnvironmentVariable("Ivo_Igov"));
                    sauceOptions.Add("accessKey", Environment.GetEnvironmentVariable("930c032e-9c3e-4ea4-841e-eab1aaba457e"));
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    sauceUrl = new Uri("https://Ivo_Igov:930c032e-9c3e-4ea4-841e-eab1aaba457e@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                    SetDriver(new RemoteWebDriver(sauceUrl, browserOptions));

                    ((IJavaScriptExecutor)GetDriver()).ExecuteScript($"sauce:job-name= {TestContext.CurrentContext.Test.MethodName}");

                    break;
                default:
                    throw new ArgumentException("You need to select a valid strategy.");
            }
        }

        public static void StopDriver()
        {
            var reader = new GetSettings();
            var settings = reader.GetConfigFileData();
            if (!settings.Environment.Equals("saucelabs"))
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                if (status == TestStatus.Failed)
                {
                    string outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    Screenshot ss = ((ITakesScreenshot)GetDriver()).GetScreenshot();
                    string currentDate = DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                    var relativePathToScreenshots = @"..\..\..\..\Screenshots";
                    var fullPathToScreenshots = Path.GetFullPath(Path.Combine(outputDirectory, relativePathToScreenshots));
                    string screenshotFileName = "//Screenshot{0}.png";

                    ss.SaveAsFile(fullPathToScreenshots + String.Format(screenshotFileName, currentDate), ScreenshotImageFormat.Png);
                }
            }
            else
            {
                SauceLabsClean();
            }

            Console.WriteLine($"Date and Time: {DateTime.Now}");
            Console.WriteLine($"Browser Name: {GetDriver().Capabilities.GetCapability("browserName")}");
            Console.WriteLine($"Browser Version: {GetDriver().Capabilities.GetCapability("browserVersion")}");
            Console.WriteLine($"Platform Version: {GetDriver().Capabilities.GetCapability("platformName")}");

            GetDriver().Quit();
            SetDriver(null);
        }


        public static void CleanCookies()
        {
            GetDriver().Manage().Cookies.DeleteAllCookies();
        }

        public static void SauceLabsClean()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)_driver).ExecuteScript(script);
        }
    }
}
