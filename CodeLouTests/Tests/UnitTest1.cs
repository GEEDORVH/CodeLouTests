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
using OpenQA.Selenium.Interactions;

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
        public AddUserPage _addUserPage;
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
            _addUserPage = new AddUserPage(_driver);
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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _navigationBar.adminIcon.Click();
            wait.Until(d => _adminManagementPage.searchForUserTextBox.Displayed);
            _adminManagementPage.searchForUserTextBox.SendKeys("Admin");
            _seleniumHelpers.ScrollElementIntoViewAndClick(_adminManagementPage.adminSearchButton);
            wait.Until(d => _adminManagementPage.editPencilButton.Displayed);
            _seleniumHelpers.ScrollElementIntoViewAndClick(_adminManagementPage.editPencilButton);
            wait.Until(d => _adminManagementPage.editPageUsernameTextBox.Displayed);
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.Control + "a");
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.Delete);
            _adminManagementPage.editPageUsernameTextBox.SendKeys(Keys.Control + "a");
            _adminManagementPage.editPageUsernameTextBox.SendKeys(Keys.Delete);
            _adminManagementPage.employeeNameTextBox.SendKeys("Corey");
            _adminManagementPage.editPageUsernameTextBox.SendKeys("Admin123");
            _adminManagementPage.adminSaveButton.Click();
            wait.Until(d => _addUserPage.userSaveButton.Displayed);

            //Assert

        }
        [TestMethod]
        public void Add_NewUser_AndLogin()
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(_driver);
            var faker = new Faker();
            string username = faker.Name.FirstName();
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            //wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            //wait.Until(d => _helpPage.helpIcon.Displayed);
            _navigationBar.adminIcon.Click();
            //wait.Until(d => _adminManagementPage.searchForUserTextBox.Displayed);
            _adminManagementPage.addButton.Click();
            //wait.Until(d => _addUserPage.userRoleDropdown.Displayed);
            _addUserPage.userRoleDropdown.Click();
            _addUserPage.userRoleDropdown.SendKeys(Keys.Down);
            actions.SendKeys(Keys.Enter).Perform();
            _addUserPage.userEmployeeTextBox.Click();
            _addUserPage.userEmployeeTextBox.SendKeys("r");
            _addUserPage.userEmployeeTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(950).Wait();
            _addUserPage.userEmployeeTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(950).Wait();
            _addUserPage.userEmployeeTextBox.SendKeys(Keys.Enter);
            _addUserPage.statusDropdown.Click();
            _addUserPage.statusDropdown.SendKeys("e");
            actions.SendKeys(Keys.Enter).Perform();
            Task.Delay(950).Wait();
            _addUserPage.userNameTextBox.SendKeys(username);
            Task.Delay(950).Wait();
            _addUserPage.passwordTextBox.SendKeys("Admin123$");
            _addUserPage.confirmPasswordTextBox.SendKeys("Admin123$");
            _addUserPage.saveButton.Click();
            //Task.Delay(1000).Wait();
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
            
        }
    }
}
