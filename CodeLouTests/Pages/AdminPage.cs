using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
    public class AdminPage
    {
        public IWebDriver _driver;

        public AdminPage(IWebDriver driver)
        {
            _driver = driver;

        }

    }
}
