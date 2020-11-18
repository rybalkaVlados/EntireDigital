using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class CompleteProfileData
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By inputFirstName = By.Id("FirstName");
        private readonly By inputLastName = By.Id("LastName");
        private readonly By inputBirthCountry = By.Id("select2-BirthCountryId-container");
        private readonly By inputBirthCity = By.Id("BirthCity");
        private readonly By inputBirthData = By.Name("BirthDate");
        private readonly By inputResidenceCity = By.Id("ResidenceCity");
        private readonly By inputResidenceAddress = By.Id("ResidenceAddress");
        private readonly By inputResidenceZipCode = By.Id("ResidenceZipCode");
        private readonly By inputMobilePhone = By.Id("MobilePhone");
        private readonly By btnSave = By.Id("btnSave");      
        #endregion

        #region IWebElements
        private IWebElement _inputFirstName => _webDriver.FindElement(inputFirstName);
        private IWebElement _inputLastName => _webDriver.FindElement(inputLastName);
        private IWebElement _inputBirthCountry => _webDriver.FindElement(inputBirthCountry);
        private IWebElement _inputBirthCity => _webDriver.FindElement(inputBirthCity);
        private IWebElement _inputBirthData => _webDriver.FindElement(inputBirthData);
        private IWebElement _inputResidenceCity => _webDriver.FindElement(inputResidenceCity);
        private IWebElement _inputResidenceAddress => _webDriver.FindElement(inputResidenceAddress);
        private IWebElement _inputResidenceZipCode => _webDriver.FindElement(inputResidenceZipCode);
        private IWebElement _inputMobilePhone => _webDriver.FindElement(inputMobilePhone);
        private IWebElement _btnSave => _webDriver.FindElement(btnSave);
        #endregion

        private Random _random = new Random();


        public CompleteProfileData(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CompleteProfileData CompleteDataUpper(string firstName, string lastName, string birthCity, string birthData)
        {
            WaitUntil.WaitElement(_webDriver, inputFirstName);
            int randomNumber = _random.Next(0, 9999999);

            _inputFirstName.SendKeys(firstName);
            _inputLastName.SendKeys(lastName + randomNumber );
            _inputBirthCity.SendKeys(birthCity);
            _inputBirthData.SendKeys(birthData);
            return this;
        }

        public CompleteProfileData CompleteDataLower(string residenceCity, string residenceAddress, string zipCode, string mobilePhone)
        {
            _inputResidenceCity.SendKeys(residenceCity);
            _inputResidenceAddress.SendKeys(residenceAddress);
            _inputResidenceZipCode.SendKeys(zipCode);
            _inputMobilePhone.SendKeys(mobilePhone);

            return this;
        }

        public SummaryPageObject ClickSave()
        {
            _btnSave.Click();
            return new SummaryPageObject(_webDriver);
        }
    }
}
