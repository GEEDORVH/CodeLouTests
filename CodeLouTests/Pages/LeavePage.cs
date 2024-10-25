using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests.Pages
{
    public class LeavePage
    {
        public IWebDriver _driver;

        public LeavePage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement leaveTypeDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-select-text-input']"));

    }
}
