﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace CodeLouTests
{
    [TestClass]
    public class CodeLouTests
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
        public LeavePage _leavePage;

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
            _leavePage = new LeavePage(_driver);
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
            string username = _addUserPage.AddUser();
            Assert.IsTrue(_navigationBar.adminIcon.Displayed);
            _adminManagementPage.searchForUserTextBox.SendKeys(username);
            wait.Until(d => _adminManagementPage.editPencilButton.Displayed);
            _seleniumHelpers.ScrollElementIntoViewAndClick(_adminManagementPage.adminSearchButton);
            wait.Until(d => _adminManagementPage.editPencilButton.Displayed);
            _seleniumHelpers.ScrollElementIntoViewAndClick(_adminManagementPage.editPencilButton);
            wait.Until(d => _adminManagementPage.editPageUsernameTextBox.Displayed);
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.Control + "a");
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.Delete);
            _adminManagementPage.editPageUsernameTextBox.SendKeys(Keys.Control + "a");
            _adminManagementPage.editPageUsernameTextBox.SendKeys(Keys.Delete);
            _adminManagementPage.employeeNameTextBox.SendKeys("r");
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(1000).Wait();
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(1000).Wait();
            _adminManagementPage.employeeNameTextBox.SendKeys(Keys.Enter);
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
            
            //Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _navigationBar.adminIcon.Click();
            string username = _addUserPage.AddUser();
            wait.Until(d => _adminManagementPage.searchForUserTextBox.Displayed);
            _adminManagementPage.profileDropdown.Click();
            _adminManagementPage.logOutButton.Click();
            wait.Until(d => _loginPage.passwordTextBox.Displayed);
            Assert.IsTrue(_loginPage.passwordTextBox.Displayed);
            _loginPage.userNameTextBox.SendKeys(username);
            _loginPage.passwordTextBox.SendKeys("Admin123$");
            _loginPage.LoginButton.Click();
            wait.Until(d => _adminManagementPage.profileDropdown.Displayed);
            Assert.IsTrue(_adminManagementPage.profileDropdown.Displayed);
            //Assert
            Assert.IsTrue(_navigationBar.adminIcon.Displayed);
            Assert.IsTrue(_myInfoPage.myInfoNav.Displayed);
            Assert.IsTrue(_navigationBar.leaveButton.Displayed);
        }

        [TestMethod]
        [DataRow("CoreyTestText.txt")]
        [DataRow("TestTextFile.txt")]
        public void Upload_A_File(string testFileName)
        {
            var baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(baseDirectory, testFileName);
            // Arrange
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            // Act
            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            Assert.IsTrue(_helpPage.helpIcon.Displayed);
            _myInfoPage.myInfoNav.Click();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _seleniumHelpers.ScrollElementIntoViewAndClick(_myInfoPage.addAttachmentButton);
            Task.Delay(1000).Wait();
            _myInfoPage.browseButton.SendKeys(filePath);
            _myInfoPage.attachmentSaveButton.Click();
            wait.Until(d => _myInfoPage.fileNameCell(testFileName).Displayed);
            string fileNameText = _myInfoPage.fileNameCell(testFileName).Text;
            wait.Until(d => _myInfoPage.typeCell.Displayed);
            string typeCell = _myInfoPage.typeCell.Text;
            // Assert
            Assert.AreEqual("text/plain", typeCell);
            Assert.AreEqual(testFileName, fileNameText);
        }

        [TestMethod]
        public void Apply_For_Leave()
        {
            //Arrange

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            //Act

            _driver.Navigate().GoToUrl(_loginPage.openSourceUrl);
            wait.Until(d => _loginPage.userNameTextBox.Displayed);
            _loginPage.Login();
            wait.Until(d => _landingPage.applyLeaveButton.Displayed);
            _landingPage.applyLeaveButton.Click();
            wait.Until(d => _helpPage.helpIcon.Displayed);
            _leavePage.leaveTypeDropdown.Click();
            _leavePage.leaveTypeDropdown.SendKeys(Keys.ArrowDown);
            _leavePage.leaveTypeDropdown.SendKeys(Keys.Enter);
            Task.Delay(1000).Wait();
            string leaveBalance = _leavePage.leaveBalance.Text;
            Task.Delay(1000).Wait();
            int leaveBalanceInt = (int)double.Parse(leaveBalance.Split(' ')[0]);
            string fromDate = _leavePage.GetNextWeekday(DateTime.Now);
            if (leaveBalanceInt >= 1)

            {
                _leavePage.fromDateTextBox.SendKeys(fromDate);
            }
            else

            {
                Console.WriteLine("You do not have enough time to apply for leave");
            }
            string comment = "Its my birthday";
            _leavePage.commentTextBox.SendKeys(comment);
            _leavePage.applyButton.Click();
            Task.Delay(1000).Wait();
            _leavePage.leaveNavButton.Click();
            Task.Delay(2500).Wait();
            bool fromDateIsVisible = _leavePage.mainLeaveRow(_leavePage.ReformatDateTime(fromDate)).Displayed;
            Assert.IsTrue(fromDateIsVisible);
            bool isvisibleRow = _leavePage.row(_leavePage.ReformatDateTime(fromDate)).Displayed;
            bool commentCellVisdible = _leavePage.commentsCell(_leavePage.ReformatDateTime(fromDate), comment).Displayed;
            _leavePage.myLeaveButton.Click();
            wait.Until(d => _leavePage.resetButton.Displayed);
            _leavePage.cancelLeaveButton.Click();
            wait.Until(d => _leavePage.afterLeaveStatus.Displayed);
            Assert.IsTrue(_leavePage.afterLeaveStatus.Displayed);

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