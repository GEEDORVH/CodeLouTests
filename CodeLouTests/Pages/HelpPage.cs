using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{
    public class HelpPage
    {
        public IWebDriver _driver;

        public HelpPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement helpIcon => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-question-lg']"));
        public IWebElement searchBar => _driver.FindElement(By.XPath("//input[@id='query']"));
        public IWebElement adminUserGuideLink => _driver.FindElement(By.XPath("//span[normalize-space()='Admin User Guide']"));
        public IWebElement employeeUserGuide => _driver.FindElement(By.XPath("//span[normalize-space()='Employee User Guide']"));
        public IWebElement mobileApp => _driver.FindElement(By.XPath("//span[normalize-space()='Mobile App']"));
        public IWebElement awsGuide => _driver.FindElement(By.XPath("//span[normalize-space()='AWS Guide']"));
        public IWebElement faqsButton => _driver.FindElement(By.XPath("//span[normalize-space()='FAQs']"));
        public IWebElement signIn => _driver.FindElement(By.XPath("//a[@class='sign-in']"));
    }
}
