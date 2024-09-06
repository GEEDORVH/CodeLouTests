using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;

namespace CodeLouTests
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver _driver;
        public ApplyPage _applyPage;
        public SeleniumHelpers _seleniumHelpers;
        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _applyPage = new ApplyPage(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver);
        }
        [TestMethod]
        public void NavigateToApplyPage()
        {
            _driver.Navigate().GoToUrl(_applyPage.applyPageUrl);
        }

        [TestMethod]
        public void FillOutApplyForm() 
        {
            //Act
            _driver.Navigate().GoToUrl(_applyPage.applyPageUrl);
            //
            _applyPage.emailTextBox.SendKeys("coreyraygilbert@gmail.com");
            _applyPage.firstNameTextBox.SendKeys("Corey");
            _applyPage.lastNameTextBox.SendKeys("Gilbert");
            _applyPage.preferedNameTextBox.SendKeys("Corey Gilbert");
            _applyPage.phoneNumberTextBox.SendKeys("502-555-5555");
            _applyPage.birthDateTextBox.SendKeys("05/05/1935");
            _applyPage.streetAddressTextBox.SendKeys("2222 Test Street");
            _applyPage.cityTextBox.SendKeys("Louisville");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.stateDropDown, "KY");
            _applyPage.zipCodeTextBox.SendKeys("40218");
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.submitButton);
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.residenceDropDown, "Jefferson");


            //Assert

        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
            
        }
    }
}
