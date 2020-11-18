using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class SummaryPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By managedTitles = By.CssSelector("div.widget-chart-flex div.widget-numbers div div span");
     
        private readonly By btnWriteTestArticle = By.XPath("//div[@class='col-md-12']/div/div/a");
        private readonly By textEvaluating = By.XPath("//div[@class='col-md-12']/div/h5");
        private readonly By getFullName = By.XPath("//div[@class='app-header-right']/div[2]/div/div/div[2]/div");
        #endregion

        #region AWebElements
        private IWebElement _managedTitles => _webDriver.FindElement(managedTitles);

        private IWebElement _btnWriteTestArticle => _webDriver.FindElement(btnWriteTestArticle);
        private IWebElement _textEvaluating => _webDriver.FindElement(textEvaluating);
        private IWebElement _getFullName => _webDriver.FindElement(getFullName);
        #endregion

     
        
        public SummaryPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public string CheckStatistics()
        {
            string getManagedTitles = _managedTitles.Text;
            return getManagedTitles;
        }


        public SelectCategoryTestArticlePageObject GoWriteTestArticle()
        {
            WaitUntil.WaitElement(_webDriver, btnWriteTestArticle);
            _btnWriteTestArticle.Click();
            return new SelectCategoryTestArticlePageObject(_webDriver);
        }

        public string GetEvaluatingText()
        {
            WaitUntil.WaitElement(_webDriver, textEvaluating);
            string text = _textEvaluating.Text;
            return text;
        }

        public string GetFullName()
        {
            string text = _getFullName.Text;
            return text;
        }

        
    }
}
