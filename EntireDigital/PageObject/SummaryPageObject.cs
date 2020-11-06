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


        #endregion

        #region AWebElements
        private IWebElement _managedTitles => _webDriver.FindElement(managedTitles);

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
    }
}
