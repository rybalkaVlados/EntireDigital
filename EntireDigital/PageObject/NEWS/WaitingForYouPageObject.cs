using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class WaitingForYouPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By titleID = By.XPath("//tr[@class='odd']/td");
        private readonly By buttonGetIt = By.XPath("//tr[@class='odd']/th/a");
        private readonly By btnDetails = By.XPath("//tr[@class='odd']/td[8]/a");
        private readonly By confirmAndWrite = By.Id("btnGetWrite");
        private readonly By btnGetIt = By.Id("btnGetItFromGuidelines");



        #endregion

        #region IWebElements
        private IWebElement _titleID => _webDriver.FindElement(titleID);
        private IWebElement _buttonGetIt => _webDriver.FindElement(buttonGetIt);
        private IWebElement _btnDetails => _webDriver.FindElement(btnDetails);
        private IWebElement _confirmAndWrite => _webDriver.FindElement(confirmAndWrite);
        private IWebElement _btnGetIt => _webDriver.FindElement(btnGetIt);
        #endregion


        public WaitingForYouPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string CheckTitleID()
        {
            WaitUntil.WaitElement(_webDriver, titleID);
            string articleID = _titleID.Text;
            return articleID;
        }

        public WriteArticlePageObject GetItArticle()
        {
            _buttonGetIt.Click();
            WaitUntil.WaitElement(_webDriver, confirmAndWrite);
            _confirmAndWrite.Click();
            return new WriteArticlePageObject(_webDriver);
        }

        public WriteArticlePageObject GetItЕhroughDetails()
        {
            _btnDetails.Click();
            WaitUntil.WaitElement(_webDriver, btnGetIt);
            _btnGetIt.Click();
            WaitUntil.WaitElement(_webDriver, confirmAndWrite);
            _confirmAndWrite.Click();
            return new WriteArticlePageObject(_webDriver);
        }

    }
}
