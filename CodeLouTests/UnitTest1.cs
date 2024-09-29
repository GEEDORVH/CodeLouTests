using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Bogus;

namespace CodeLouTests
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver _driver;
        public LoginPage _loginPage;
        public MyInfoPage _myInfoPage;
        public SeleniumHelpers _seleniumHelpers;
        public LandingPage _landingPage;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _myInfoPage = new MyInfoPage(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver);
            _landingPage = new LandingPage(_driver);
            _driver.Manage().Window.Maximize();
        }
        

        [TestMethod]
        public void ChaneUserName() 
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var faker = new Faker();
            string firstName = faker.Name.FirstName();
            string lastName = faker.Name.LastName();
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.userNameTextBox.SendKeys("Admin");
            _loginPage.passwordTextBox.SendKeys("admin123");
            _loginPage.clickLoginButton.Click();
            wait.Until(d => _myInfoPage.myInfoNav.Displayed);
            _myInfoPage.myInfoNav.Click();
            wait.Until(d => _myInfoPage.firstNameTextBox.Displayed);
            _myInfoPage.firstNameTextBox.SendKeys(Keys.Control + "a");
            _myInfoPage.firstNameTextBox.SendKeys(Keys.Delete);
            _myInfoPage.lastNameTextBox.SendKeys(Keys.Control + "a");
            _myInfoPage.lastNameTextBox.SendKeys(Keys.Delete);
            _myInfoPage.firstNameTextBox.SendKeys(firstName);
            _myInfoPage.lastNameTextBox.SendKeys(lastName);
            _myInfoPage.saveButton.ClickViaJavaScript(_driver);
            _driver.Navigate().Refresh();
            wait.Until(d => _landingPage.userDropDown.Displayed);
            //Assert
            Assert.AreEqual($"{firstName} {lastName}", _landingPage.userDropDown.Text);
            
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
            
        }
    }
}
