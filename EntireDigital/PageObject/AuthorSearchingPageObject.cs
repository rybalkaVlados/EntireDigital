using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class AuthorSearchingPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By createButton = By.CssSelector("div.d-inline-block button.btn-shadow ");
        private readonly By redEsteriBlogTest = By.XPath("//div[@class='page-title-actions']/div/div/ul/li[3]/a");

        private readonly By summaryTab = By.XPath("//a[@title='Summary']");
        #endregion

        #region IWebElements
        private IWebElement _createButton => _webDriver.FindElement(createButton);
        private IWebElement _redEsteriBlogTest => _webDriver.FindElement(redEsteriBlogTest);
    
        private IWebElement _summaryTab => _webDriver.FindElement(summaryTab);
        #endregion

        public AuthorSearchingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateTitleForm CreateButton()
        {
            _createButton.Click();
            Thread.Sleep(500);
            _redEsteriBlogTest.Click();

            return new CreateTitleForm(_webDriver);
        }

        public SummaryPageObject GoToSummaryPage()
        {
            _summaryTab.Click();
            return new SummaryPageObject(_webDriver);
        }
    }
}
