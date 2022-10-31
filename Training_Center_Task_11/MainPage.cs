using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_11
{
    public class MainPage
    {
        protected string _url = @"https://www.yahoo.com/";
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.URL = _url;
        }

        public string URL { get; set; }

        public IWebDriver Driver
        {
            get
            {
                return this._driver;
            }
            set
            {
                this._driver = value;
            }
        }
    }
}
