using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Bogus;
using System.Linq;
using CodeLouTests.Pages;

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
        public HelpPage _helpPage;
        public AdminPage _adminPage;
        public NavigationBar _navigationBar;
        public AdminManagementPage _adminManagementPage;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _myInfoPage = new MyInfoPage(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver);
            _landingPage = new LandingPage(_driver);
            _helpPage = new HelpPage(_driver);
            _adminPage = new AdminPage(_driver);
            _navigationBar = new NavigationBar(_driver);
            _adminManagementPage = new AdminManagementPage(_driver);
            _driver.Manage().Window.Maximize();
        }
        

        [TestMethod]
        public void Change_UserName() 
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var faker = new Faker();
            string firstName = faker.Name.FirstName();
            string lastName = faker.Name.LastName();
            //Act
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
           
            
            _loginPage.Login();
            wait.Until(d => _myInfoPage.myInfoNav.Displayed);
            Assert.AreEqual(_landingPage.landingPageUrl, _driver.Url);
            _myInfoPage.myInfoNav.Click();
            wait.Until(d => _myInfoPage.firstNameTextBox.Displayed);
            Assert.AreEqual(_myInfoPage.myInfoPageUrl, _driver.Url);
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
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
        [TestMethod]
        public void HelpPage_Naviagtion()
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);

            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _helpPage.helpIcon.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            wait.Until(d => _helpPage.searchBar.Displayed);
            //Assert
            Assert.IsTrue(_helpPage.searchBar.Displayed);
            Assert.IsTrue(_helpPage.adminUserGuideLink.Displayed);
            Assert.IsTrue(_helpPage.employeeUserGuide.Displayed);
            Assert.IsTrue(_helpPage.mobileApp.Displayed);
            Assert.IsTrue(_helpPage.awsGuide.Displayed);
            Assert.IsTrue(_helpPage.faqsButton.Displayed);
            Assert.IsTrue(_helpPage.signIn.Displayed);
        }
        [TestMethod]
        public void Search_And_Edit_Users()
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _navigationBar.adminIcon.Click();
            wait.Until(d => _adminManagementPage.addButton.Displayed);
            _adminManagementPage.addButton.Click();
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
