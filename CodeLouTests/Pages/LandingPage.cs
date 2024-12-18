﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
    public  class LandingPage
    {
        public IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public string landingPageUrl = "https://opensource-demo.orangehrmlive.com/web/dashboard/index";

        public IWebElement userDropDown => _driver.FindElement(By.XPath("//p[@class='oxd-userdropdown-name']"));
        public IWebElement applyLeaveButton => _driver.FindElement(By.XPath("//button[@title='Apply Leave']//*[name()='svg']"));
    }
}
