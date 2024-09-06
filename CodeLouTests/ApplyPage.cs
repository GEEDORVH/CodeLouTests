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
   
    public class ApplyPage
    {
        public IWebDriver _driver;

        public ApplyPage(IWebDriver driver)
        {
           _driver = driver;

        }

        public string applyPageUrl = "https://code-you.org/apply/";
        public IWebElement emailTextBox => _driver.FindElement(By.Id("tfa_215"));
        public IWebElement emailTextBoxXpath => _driver.FindElement(By.XPath("//input[@id='tfa_215']"));
        public IWebElement firstNameTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_2']"));
        public IWebElement lastNameTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_3']"));
        public IWebElement preferedNameTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_1230']"));
        public IWebElement phoneNumberTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_216']"));
        public IWebElement birthDateTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_5']"));
        public IWebElement streetAddressTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_6']"));
        public IWebElement cityTextBox => _driver.FindElement(By.XPath("//input[@id='tfa_7']"));
        public IWebElement stateDropDown => _driver.FindElement(By.Id("tfa_220"));
        public IWebElement zipCodeTextBox => _driver.FindElement(By.Id("tfa_9"));
        public IWebElement residenceDropDown => _driver.FindElement(By.Id("tfa_59"));
        public IWebElement genderDropDown => _driver.FindElement(By.Id(""));
        public IWebElement raceCheckBoxes => _driver.FindElement(By.Id(""));
        public IWebElement fluentDropDown => _driver.FindElement(By.Id(""));
        public IWebElement authDropDown => _driver.FindElement(By.Id(""));
        public IWebElement veteranDropDown => _driver.FindElement(By.Id(""));
        public IWebElement lgbtqDropDown => _driver.FindElement(By.Id(""));
        public IWebElement disabilityDropDown => _driver.FindElement(By.Id(""));
        public IWebElement employmentDropDown => _driver.FindElement(By.Id(""));
        public IWebElement techIndustryDropDown => _driver.FindElement(By.Id(""));
        public IWebElement felonyDropDown => _driver.FindElement(By.Id(""));
        public IWebElement snapDropDown => _driver.FindElement(By.Id(""));
        public IWebElement housingDropDown => _driver.FindElement(By.Id(""));
        public IWebElement educationDropDown => _driver.FindElement(By.Id(""));
        public IWebElement enrolledCollegeDropDown => _driver.FindElement(By.Id(""));
        public IWebElement fullTimeEmploymentDropDown => _driver.FindElement(By.Id(""));
        public IWebElement laptopDropDown => _driver.FindElement(By.Id(""));
        public IWebElement stableInternetDropDown => _driver.FindElement(By.Id(""));
        public IWebElement computerSkillsRadioButton => _driver.FindElement(By.Id(""));
        public IWebElement commitWorkDropDown => _driver.FindElement(By.Id(""));
        public IWebElement iAgreeCheckBox => _driver.FindElement(By.Id("tfa_545"));
        public IWebElement submitButton => _driver.FindElement(By.Id("submit_button"));
    }
}
