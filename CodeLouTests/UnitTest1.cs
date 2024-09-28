using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace CodeLouTests
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver _driver;
        public LoginPage _loginPage;
        public MyInfoPage _myInfoPage;
        public SeleniumHelpers _seleniumHelpers;
        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _myInfoPage = new MyInfoPage(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver);
            _driver.Manage().Window.Maximize();
        }
        

        [TestMethod]
        public void ChaneUserName() 
        {
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            //
            _loginPage.userNameTextBox.SendKeys("Admin");
            _loginPage.passwordTextBox.SendKeys("admin123");
            _loginPage.clickLoginButton.Click();
            _myInfoPage.myInfoClick.Click();
            //Assert
            
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
            
        }
    }
}
