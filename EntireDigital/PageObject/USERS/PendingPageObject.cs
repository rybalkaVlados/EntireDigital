using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class PendingPageObject
    {

        private IWebDriver _webDriver;


        #region Locators
        private readonly By inputSearch = By.XPath("//input[@type='search']");
        private readonly By btnApprove = By.XPath("//button[@title='Approve']");
        private readonly By btnConfirm = By.XPath("//button[text()='Confirm']");
        #endregion

        #region IWebElements
        private IWebElement _inputSearch => _webDriver.FindElement(inputSearch);
        private IWebElement _btnApprove => _webDriver.FindElement(btnApprove);
        private IWebElement _btnConfirm => _webDriver.FindElement(btnConfirm);
        #endregion






        public PendingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public PendingPageObject SearchTestArticle(string text)
        {
            WaitUntil.WaitElement(_webDriver, inputSearch);
            _inputSearch.SendKeys(text);
            return this;
        }
        




        public PendingPageObject ApproveTestArticle()
        {
            WaitUntil.WaitSomeInterval(2);
            _btnApprove.Click();
            WaitUntil.WaitElement(_webDriver, btnConfirm);
            _btnConfirm.Click();
            return this;
        }




    }
}
