using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class EmptyWindow
    {
        private IWebDriver _webDriver;



        public EmptyWindow(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToURL(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        


    }
}
