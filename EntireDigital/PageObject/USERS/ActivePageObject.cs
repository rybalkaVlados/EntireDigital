using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class ActivePageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By btnCreate = By.CssSelector("div.page-title-wrapper a.btn-shadow");


        #endregion

        #region IWebElements
        private IWebElement _btnCreate => _webDriver.FindElement(btnCreate);

        #endregion


        public ActivePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public FormCreateUser ClickCreateUser()
        {
            WaitUntil.WaitElement(_webDriver, btnCreate);
            _btnCreate.Click();
            return new FormCreateUser(_webDriver);
        }



    }
}
