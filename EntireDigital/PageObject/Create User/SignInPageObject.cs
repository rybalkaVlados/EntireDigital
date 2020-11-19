using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    public class SignInPageObject
    {
        private IWebDriver _webDriver;

        #region Locators

        private readonly By btnGetStarted = By.CssSelector("div.register-row a.button ");
        private readonly By inputEmail = By.XPath("//input[@placeholder='Email']");
        private readonly By inputPassword = By.Id("password");
        private readonly By inputRepeatPassword = By.Id("password2");
        private readonly By checkBoxAccept = By.Id("checkTerms");
        private readonly By btnRegister = By.Name("commit");
        private readonly By checkWelcomeMessage = By.XPath("//h3[text()='Thank you for registering!!']");
        #endregion

        #region IWebElements

        private IWebElement _btnGetStarted => _webDriver.FindElement(btnGetStarted);
        private IWebElement _inputEmail => _webDriver.FindElement(inputEmail);
        private IWebElement _inputPassword => _webDriver.FindElement(inputPassword);
        private IWebElement _inputRepeatPassword => _webDriver.FindElement(inputRepeatPassword);
        private IWebElement _checkBoxAccept => _webDriver.FindElement(checkBoxAccept);
        private IWebElement _btnRegister => _webDriver.FindElement(btnRegister);
        private IWebElement _checkWelcomeMessage => _webDriver.FindElement(checkWelcomeMessage);
        #endregion


        public SignInPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPageObject CloseWelcomMessage()
        {
            WaitUntil.WaitElement(_webDriver, btnGetStarted);
            _btnGetStarted.Click();
            return this;
        }

        public SignInPageObject OpenNewTab()
        {
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open();");

            return this;
        }
        public SignInPageObject MoveFirstTab()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
            return this;
        }
        public SignInPageObject MoveLastTab()
        {
            WaitUntil.WaitSomeInterval(1);
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
            return this;
        }

        public SignInPageObject EnterRandomEmail(string mail)
        {
            _inputEmail.SendKeys(mail);
            return this;
        }

        public SignInPageObject EnterTwoPassword(string password, string rapeatPassword)
        {
            _inputPassword.SendKeys(password);
            _inputRepeatPassword.SendKeys(rapeatPassword);
            return this;
        }

        public SignInPageObject ClickCheckBox()
        {
            _checkBoxAccept.Click();
            return this;
        }

        public SignInPageObject Register()
        {
            _btnRegister.Click();
            return this;
        }

        public string CheckWelcomeMessage()
        {
            WaitUntil.WaitElement(_webDriver, checkWelcomeMessage);
            string getMessage = _checkWelcomeMessage.Text;
            return getMessage;
        }



    }
}
