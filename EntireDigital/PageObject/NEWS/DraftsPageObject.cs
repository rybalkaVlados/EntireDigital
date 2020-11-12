using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class DraftsPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By buttonShow = By.XPath("//tr[@class='odd']/td[7]/a");
        
        #endregion

        #region IWebElements
        private IWebElement _buttonShow => _webDriver.FindElement(buttonShow);
        
        #endregion


        public DraftsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public WriteArticlePageObject CheckArticle()
        {
            WaitUntil.WaitElement(_webDriver, buttonShow);
            _buttonShow.Click();
            return new WriteArticlePageObject(_webDriver);
        }
    }
}
