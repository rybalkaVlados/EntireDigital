
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace EntireDigital.PageObject
{
    class AuthorSearchingPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By createButton = By.CssSelector("div.d-inline-block button.btn-shadow ");
        private readonly By redEsteriBlogTest = By.XPath("//div[@class='page-title-actions']/div/div/ul/li[4]/a");

        #endregion

        #region IWebElements
        private IWebElement _createButton => _webDriver.FindElement(createButton);
        private IWebElement _redEsteriBlogTest => _webDriver.FindElement(redEsteriBlogTest);

        #endregion

        public AuthorSearchingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateTitlePageObject CreateButton()
        {
            _createButton.Click();
          
            WaitUntil.WaitElement(_webDriver, redEsteriBlogTest);
            _redEsteriBlogTest.Click();

            return new CreateTitlePageObject(_webDriver);
        }

        







    }
}
