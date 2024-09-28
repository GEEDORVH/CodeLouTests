using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V126.Emulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
    public class MyInfoPage
    {
        public IWebDriver _driver;

        public MyInfoPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement myInfoClick => _driver.FindElement(By.XPath("//span[normalize-space()='My Info']"));
    }
}
