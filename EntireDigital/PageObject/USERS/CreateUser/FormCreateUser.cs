using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class FormCreateUser
    {
        private IWebDriver _webDriver;


        #region Locators
        private readonly By inputPaypalAccount = By.Id("PaypalAccount");
        private readonly By selectCategories = By.XPath("//select[@id='AreasIds']/option");
        private readonly By btnSave = By.XPath("//button[text()='Save']");
        private readonly By inputFiscalCode = By.Id("FiscalCode");

        #endregion

        #region IWebElements
        private IWebElement _inputPaypalAccount => _webDriver.FindElement(inputPaypalAccount);
        private IWebElement _selectCategories => _webDriver.FindElement(selectCategories);
        private IWebElement _btnSave => _webDriver.FindElement(btnSave);
        private IWebElement _inputFiscalCode => _webDriver.FindElement(inputFiscalCode);
        #endregion


        public FormCreateUser(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public FormCreateUser EnterNecessaryData(string account, string code)
        {
            WaitUntil.WaitElement(_webDriver, inputPaypalAccount);
            _inputPaypalAccount.SendKeys(account);
            _inputFiscalCode.SendKeys(code);
            return new FormCreateUser(_webDriver);
        }
        public FormCreateUser SelectCategories()
        {
            _selectCategories.Click();
            return new FormCreateUser(_webDriver);
        }

        public UserDetails SaveResult()
        {
            _btnSave.Click();
            return new UserDetails(_webDriver);
        }
    }
}
