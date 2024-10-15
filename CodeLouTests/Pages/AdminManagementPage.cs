using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests.Pages
{
    public class AdminManagementPage
    {
        public IWebDriver _driver;

        public AdminManagementPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement addButton => _driver.FindElement(By.XPath("//button[normalize-space()='Add']"));
        public IWebElement searchForUserTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@class='oxd-input oxd-input--active']"));
        public IWebElement adminSearchButton => _driver.FindElement(By.XPath("//button[normalize-space()='Search']"));
        public IWebElement editPencilButton => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-pencil-fill']"));
        public IWebElement editPageUsernameTextBox => _driver.FindElement(By.XPath("//input[@autocomplete='off']"));
        public IWebElement employeeNameTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']"));
        public IWebElement adminSaveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Save']"));

    }

}
