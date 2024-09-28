﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V126.Emulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
   
    public class LoginPage
    {
        public IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
           _driver = driver;

        }

        public string openSourceUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public IWebElement userNameTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Username']"));
        public IWebElement passwordTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        public IWebElement clickLoginButton => _driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
    }
}