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
    public class SeleniumHelpers
    {
        private IWebDriver _driver;
        public SeleniumHelpers(IWebDriver driver)
        {
          _driver = driver;
        }
        public void ScrollElementIntoViewAndClick(IWebElement element)
        {
            Actions act = new Actions(_driver);
            act.ScrollToElement(element).Perform();
            element.Click(); 
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }

    }
}
