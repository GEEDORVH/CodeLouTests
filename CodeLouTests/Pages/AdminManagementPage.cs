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
    }

}
