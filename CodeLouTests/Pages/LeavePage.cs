using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
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
        public IWebElement leaveBalance => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-leave-balance-text']"));
        public IWebElement fromDateTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-grid-4 orangehrm-full-width-grid']//div[1]//div[1]//div[2]//div[1]//div[1]//input[1]"));
        public IWebElement toDateTextBox => _driver.FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[2]"));
        public IWebElement applyButton => _driver.FindElement(By.XPath("//button[normalize-space()='Apply']"));
        public IWebElement commentTextBox => _driver.FindElement(By.XPath("//textarea[@class='oxd-textarea oxd-textarea--active oxd-textarea--resize-vertical']"));
        public IWebElement leaveNavButton => _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name'][normalize-space()='Leave']"));
        public IWebElement mainLeaveRow(string date) => _driver.FindElement(By.XPath($"//div[contains(text(),'{date}')]"));
        public IWebElement commentsLeaveRow(string date, string comment) => _driver.FindElement(By.XPath($"//div[contains(text(),'{date}')]")).FindElement(By.XPath($".//div[text()='{comment}']"));
        public IWebElement row(string targetDate) => _driver.FindElement(By.XPath($"//div[@class='oxd-table-row oxd-table-row--with-border' and @role='row'][.//div[text()='{targetDate}']]"));
        public List<IWebElement> cells(string targetDate) => row(targetDate).FindElements(By.XPath(".//div[@role='cell']")).ToList<IWebElement>();
        public IWebElement commentsCell(string targetDate, string comment) => row(targetDate).FindElement(By.XPath($".//div[@role='cell' and contains(text(), '{comment}')]"));
        public IWebElement myLeaveButton => _driver.FindElement(By.XPath("//a[normalize-space()='My Leave']"));
        public IWebElement resetButton => _driver.FindElement(By.XPath("//button[normalize-space()='Reset']"));
        public IWebElement leaveStatus => _driver.FindElement(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell' and @role='cell']//div[text()='Pending Approval (1.00)']"));
        public IWebElement afterLeaveStatus => _driver.FindElement(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell' and @role='cell']//div[text()='Cancelled Approval (1.00)']"));
        public IWebElement cancelLeaveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Cancel']"));
        public string GetNextWeekday(DateTime startDate)

        {

            while (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)

            {

                startDate = startDate.AddDays(1);

            }

            return startDate.ToString("yyyy-MM-dd");

        }
        public string ReformatDateTime(string date)

        {

            DateTime dateTime = DateTime.Parse(date);

            return dateTime.ToString("yyyy-dd-MM");

        }

    }
}
