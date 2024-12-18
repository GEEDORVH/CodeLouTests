﻿using Bogus;
using CodeLouTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
    public class AddUserPage
    {
        public IWebDriver _driver;
        public AdminManagementPage _adminPage;

        public AddUserPage(IWebDriver driver)
        {
            _adminPage = new AdminManagementPage(driver);
            _driver = driver;

        }
        public IWebElement userSaveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Save']"));
        public IWebElement userRoleDropdown => _driver.FindElement(By.XPath("(//div[contains(text(),'-- Select --')])[1]"));
        public IWebElement userEmployeeTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']"));
        public IWebElement statusDropdown => _driver.FindElement(By.XPath("//div[contains(text(),'-- Select --')]"));
        public IWebElement userNameTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-form-row']//div[@class='oxd-grid-2 orangehrm-full-width-grid']//div[@class='oxd-grid-item oxd-grid-item--gutters']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@class='oxd-input oxd-input--active']"));
        public IWebElement passwordTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-grid-item oxd-grid-item--gutters user-password-cell']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@type='password']"));
        public IWebElement confirmPasswordTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-grid-item oxd-grid-item--gutters']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@type='password']"));
        public IWebElement saveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Save']"));

        public string AddUser()

        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(_driver);
            var faker = new Faker();
            string username = Enumerable.Range(0, int.MaxValue)
                                            .Select(i => faker.Name.FirstName())
                                            .First(name => name.Length >= 5);

            _adminPage.addButton.Click();
            wait.Until(d => this.userRoleDropdown.Displayed);
            this.userRoleDropdown.Click();
            this.userRoleDropdown.SendKeys(Keys.Down);
            actions.SendKeys(Keys.Enter).Perform();
            this.userEmployeeTextBox.Click();
            this.userEmployeeTextBox.SendKeys("r");
            this.userEmployeeTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(1000).Wait();
            this.userEmployeeTextBox.SendKeys(Keys.ArrowDown);
            Task.Delay(1000).Wait();
            this.userEmployeeTextBox.SendKeys(Keys.Enter);
            this.statusDropdown.Click();
            this.statusDropdown.SendKeys("e");
            actions.SendKeys(Keys.Enter).Perform();
            Task.Delay(1000).Wait();
            this.userNameTextBox.SendKeys(username);
            Task.Delay(1000).Wait();
            this.passwordTextBox.SendKeys("Admin123$");
            this.confirmPasswordTextBox.SendKeys("Admin123$");
            this.saveButton.Click();
            return username;
        }
    }
}
