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
        private readonly By draftsTab = By.XPath("//a[@title='Drafts']");
        private readonly By usersTab = By.XPath("//a[@title='Users']");
        private readonly By pendingTab = By.XPath("//a[@title='Users']/following-sibling::ul/li[2]/a");
        #endregion

        #region IWebElements
        private IWebElement _createButton => _webDriver.FindElement(createButton);
        private IWebElement _redEsteriBlogTest => _webDriver.FindElement(redEsteriBlogTest);
    
        private IWebElement _summaryTab => _webDriver.FindElement(summaryTab);
        private IWebElement _draftsTab => _webDriver.FindElement(draftsTab);
        private IWebElement _usersTab => _webDriver.FindElement(usersTab);
        private IWebElement _pendingTab => _webDriver.FindElement(pendingTab);

        #endregion

        public AuthorSearchingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateTitlePageObject CreateButton()
        {
            _createButton.Click();
            Thread.Sleep(500);
            _redEsteriBlogTest.Click();

            return new CreateTitlePageObject(_webDriver);
        }

        public SummaryPageObject GoToSummaryPage()
        {
            _summaryTab.Click();
            return new SummaryPageObject(_webDriver);
        }

        public SummaryPageObject GoToDraftsPage()
        {
            WaitUntil.WaitElement(_webDriver, draftsTab);
            _draftsTab.Click();
            return new SummaryPageObject(_webDriver);
        }

        public AuthorSearchingPageObject GoToUsersPage()
        {
            WaitUntil.WaitElement(_webDriver, usersTab);
            _usersTab.Click();
            return this;
        }

        public PendingPageObject GoToPendingPage()
        {
            WaitUntil.WaitElement(_webDriver, pendingTab);
            _pendingTab.Click();
            return new PendingPageObject(_webDriver);
        }

    }
}
