using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By emailField = By.Name("email");
        private readonly By password = By.Name("password");
        private readonly By submitButton = By.XPath("//button[@type='submit']");
        #endregion

        #region IWebElements
        private IWebElement _emailField => _webDriver.FindElement(emailField);
        private IWebElement _password => _webDriver.FindElement(password);
        private IWebElement _submitButton => _webDriver.FindElement(submitButton);
        #endregion

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorSearchingPageObject LogIn(string email, string password)
        {
            _emailField.SendKeys(email);
            _password.SendKeys(password);
            _submitButton.Click();
            return new AuthorSearchingPageObject(_webDriver);
        }



    }
}
