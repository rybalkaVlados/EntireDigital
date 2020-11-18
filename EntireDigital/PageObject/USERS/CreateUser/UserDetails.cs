using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class UserDetails
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By getEmail = By.CssSelector("div.row div.row div.col-md-4 a");
        private readonly By btnSendCredentials = By.CssSelector("div.card-header-tab div.btn-actions-pane-right  button");
        private readonly By btnConfirm = By.XPath("//button[text()='Confirm']");
        #endregion

        #region IWebElements
        private IWebElement _getEmail => _webDriver.FindElement(getEmail);
        private IWebElement _btnSendCredentials => _webDriver.FindElement(btnSendCredentials);
        private IWebElement _btnConfirm => _webDriver.FindElement(btnConfirm);
        #endregion


        public UserDetails(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetEmail()
        {
            WaitUntil.WaitElement(_webDriver, getEmail);
            string email = _getEmail.Text;
            return email;
        }

        public void SendCredentials()
        {
            _btnSendCredentials.Click();
            WaitUntil.WaitElement(_webDriver, btnConfirm);
            _btnConfirm.Click();
        }


    }
}
