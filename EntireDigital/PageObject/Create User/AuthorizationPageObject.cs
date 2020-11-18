using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By emailField = By.Name("email");
        private readonly By password = By.Name("password");
        private readonly By submitButton = By.XPath("//button[@type='submit']");


        private readonly By buttonSignIn = By.LinkText("Sign in!");
        //private readonly By = By.("");
        //private readonly By = By.("");
        //private readonly By = By.("");
        //private readonly By = By.("");
        #endregion

        #region IWebElements
        private IWebElement _emailField => _webDriver.FindElement(emailField);
        private IWebElement _password => _webDriver.FindElement(password);
        private IWebElement _submitButton => _webDriver.FindElement(submitButton);

        private IWebElement _buttonSignIn => _webDriver.FindElement(buttonSignIn);
        //private IWebElement _body => _webDriver.FindElement(body);
        //private IWebElement _body => _webDriver.FindElement(body);
        //private IWebElement _body => _webDriver.FindElement(body);
        //private IWebElement _body => _webDriver.FindElement(body);
        //private IWebElement _body => _webDriver.FindElement(body);
        #endregion

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorSearchingPageObject LogIn(string email, string password)
        {
            WaitUntil.WaitSomeInterval();
            _emailField.SendKeys(email);
            _password.SendKeys(password);
            _submitButton.Click();
            return new AuthorSearchingPageObject(_webDriver);
        }


        public SignInPageObject GoToSignIn()
        {
            _buttonSignIn.Click();
            return new SignInPageObject(_webDriver);
        }


    }
}
