using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class BasePage
    {
        protected string _url = @"https://www.automationexercise.com/";
        public BasePage(IWebDriver driver)
		{
			Driver = driver;
			URL = _url;
		}
		public IWebDriver Driver { get; set; }

		public string URL { get; set; } 
	}
}
