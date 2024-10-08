using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests.Pages
{
    public class NavigationBar
    {
        public IWebDriver _driver;

        public NavigationBar(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement adminIcon => _driver.FindElement(By.XPath("//span[normalize-space()='Admin']"));
    }
}
