﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools.V126.Emulation;
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
        public string myInfoPageUrl = "https://opensource-demo.orangehrmlive.com/web/pim/viewPersonalDetails/empNumber/7";
        public IWebElement myInfoNav => _driver.FindElement(By.XPath("//span[normalize-space()='My Info']"));
        public IWebElement firstNameTextBox => _driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
        public IWebElement lastNameTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
        public IWebElement saveButton => _driver.FindElement(By.XPath("//div[@class='orangehrm-horizontal-padding orangehrm-vertical-padding']//button[@type='submit'][normalize-space()='Save']"));
        public IWebElement addAttachmentButton => _driver.FindElement(By.XPath("//button[normalize-space()='Add']"));
        public IWebElement browseButton => _driver.FindElement(By.XPath("//div[@class='oxd-file-button']"));
        public IWebElement attachmentSaveButton => _driver.FindElement(By.XPath("//div[@class='orangehrm-custom-fields']//button[@type='submit'][normalize-space()='Save']"));
        public IWebElement attachmentSectionBox => _driver.FindElement(By.XPath("//div[contains(@class, 'oxd-table-row') and .//div[text()='CoreyTestTest.txt']]"));

        
    }
}
