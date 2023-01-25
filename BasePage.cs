using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
        public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}
		public IWebDriver Driver { get; set; }
	}
}
