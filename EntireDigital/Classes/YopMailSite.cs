using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class YopMailSite
    {
        private IWebDriver _webDriver;

        private readonly By btnRandomMail = By.CssSelector("td.unlien a");
        private readonly By getRandomMail = By.Id("login");
        private readonly By btnCheckEmail = By.XPath("//input[@type='submit']");
        private readonly By iframeID = By.Id("ifmail");
        private readonly By btnValidate = By.XPath("//td[@align='center']//p[@style='text-align:center;']/a");
        private readonly By getPassword = By.XPath("//table[@align='center']/tbody/tr/td/ul/li[2]");



        private IWebElement _btnRandomMail => _webDriver.FindElement(btnRandomMail);
        private IWebElement _getRandomMail => _webDriver.FindElement(getRandomMail);
        private IWebElement _btnCheckEmail => _webDriver.FindElement(btnCheckEmail);
        private IWebElement _iframeID => _webDriver.FindElement(iframeID);
        private IWebElement _btnValidate => _webDriver.FindElement(btnValidate);
        private IWebElement _getPassword => _webDriver.FindElement(getPassword);


        public YopMailSite(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public YopMailSite GenerateRandomMail()
        {
            _btnRandomMail.Click();
            return this;
        }

        public string GetRandomMail()
        {
            WaitUntil.WaitElement(_webDriver, getRandomMail);
            string randomMail = _getRandomMail.GetAttribute("value");
            return randomMail;        
        }

        public YopMailSite CheckEmail()
        {
            WaitUntil.WaitElement(_webDriver, btnCheckEmail);
            _btnCheckEmail.Click();
            return this;
        }

        public YopMailSite GoToFrame(string frame)
        {
            WaitUntil.WaitSomeInterval(2);
            _webDriver.SwitchTo().Frame(frame);
            return this;
        }

        public CompleteProfileData ValidateEmail()
        {
            WaitUntil.WaitElement(_webDriver, btnValidate);
            _btnValidate.Click();
            return new CompleteProfileData(_webDriver);
        }

        public string GetPassword()
        {
            WaitUntil.WaitElement(_webDriver, getPassword);
            string password = _getPassword.Text;
            password = password.Substring(10);
            return password;
        }






    }
}
