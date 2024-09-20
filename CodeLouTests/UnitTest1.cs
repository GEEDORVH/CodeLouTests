using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using System.Drawing;

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
            _driver.Manage().Window.Maximize();
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
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.residenceDropDown, "Jefferson");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.genderDropDown, "Male");
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.raceCheckBoxes);
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.fluentDropDown, "Yes");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.authDropDown, "Yes");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.veteranDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.lgbtqDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.disabilityDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.employmentDropDown, "Employed full-time");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.techIndustryDropDown, "I am employed in the tech industry.");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.felonyDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.snapDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.housingDropDown, "Rent");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.educationDropDown, "Some College, No Degree");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.enrolledCollegeDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.fullTimeEmploymentDropDown, "No");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.laptopDropDown, "Yes");
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.stableInternetDropDown, "Yes");
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.computerSkillsRadioButton);
            _seleniumHelpers.SelectFromDropDownByText(_applyPage.commitWorkDropDown, "Yes");
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.iAgreeCheckBox);
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.submitButton);
            //Assert
            Assert.AreEqual("Thank you for applying. We have received your application. If you meet our requirements (18+ years old, resident of one of our counties of service) you will be placed on our waitlist and we will contact you when we get to your name. Classes start three times a year, and due to the waitlist it could take six to twelve months before we contact you. If you have any questions, please contact info@code-you.org.".Trim()
          , _applyPage.confirmationText.Text.Trim());
        }
        [TestMethod]
        public void VerifyBirthDateField()
        {
            //Act
            _driver.Navigate().GoToUrl(_applyPage.applyPageUrl);
            //
            _seleniumHelpers.ScrollElementIntoViewAndClick (_applyPage.birthDateTextBox);
            //Assert
            Assert.IsTrue(_applyPage.birthDateTextBox.Displayed);
        }
        [TestMethod]
        public void VerifyRaceCheckBox()
        {
            //Act
            _driver.Navigate().GoToUrl(_applyPage.applyPageUrl);
            //
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.raceCheckBoxes);
            //Assert
            Assert.IsTrue (_applyPage.raceCheckBoxes.Displayed);
        }
        [TestMethod]
        public void VerifyIAgreeRadioButton()
        {
            //Act 
            _driver.Navigate().GoToUrl (_applyPage.applyPageUrl);
            //
            _seleniumHelpers.ScrollElementIntoViewAndClick(_applyPage.iAgreeCheckBox);
            //Assert
            Assert.IsTrue(_applyPage.iAgreeCheckBox.Displayed);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
            
        }
    }
}
