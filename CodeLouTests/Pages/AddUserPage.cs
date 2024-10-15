using OpenQA.Selenium;
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

        public AddUserPage(IWebDriver driver)
        {
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
    }
}
