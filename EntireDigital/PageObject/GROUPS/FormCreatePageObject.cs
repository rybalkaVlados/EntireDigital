using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital.PageObject
{
    class FormCreatePageObject
    {
        private IWebDriver _webDriver;

        #region Locators

        private readonly By fieldName = By.Id("Name");
        private readonly By fieldDescription = By.Id("Description");
        private readonly By btnSave = By.CssSelector("div.col-md-12 button.btn.btn-hover-shine");
        private readonly By fieldIsActive = By.Id("IsActive");
        private readonly By elemIsActive = By.XPath("//option[text()='Active']");
        private readonly By btnRemove = By.XPath("//button[@data-target='#modalRemove']");
        private readonly By btnConfirmDeleting = By.XPath("//button[text()='Remove']");
        #endregion

        #region IWebElements

        private IWebElement _fieldName => _webDriver.FindElement(fieldName);
        private IWebElement _fieldDescription => _webDriver.FindElement(fieldDescription);
        private IWebElement _btnSave => _webDriver.FindElement(btnSave);
        private IWebElement _fieldIsActive => _webDriver.FindElement(fieldIsActive);
        private IWebElement _elemIsActive => _webDriver.FindElement(elemIsActive);
        private IWebElement _btnRemove => _webDriver.FindElement(btnRemove);
        private IWebElement _btnConfirmDeleting => _webDriver.FindElement(btnConfirmDeleting);
        #endregion

        Random _random = new Random();

        public FormCreatePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string RandomNameGroup()
        {
            int randElem = _random.Next(0, 999999);
            string fullElem = NameForCreteGroup.NAME_GROUP + " " + randElem.ToString();
            return fullElem;
        }



        public DetailsGroupPageObject CreateGroup(string name, string text)
        {
            WaitUntil.WaitElement(_webDriver, fieldName);
            _fieldName.SendKeys(name);
            _fieldDescription.SendKeys(text);
            _btnSave.Click();
            return new DetailsGroupPageObject(_webDriver);
        }

        public FormCreatePageObject MakeGroupActive()
        {
            WaitUntil.WaitElement(_webDriver, fieldIsActive);
            _fieldIsActive.Click();
            _elemIsActive.Click();
            WaitUntil.WaitElement(_webDriver, btnSave);
            _btnSave.Click();
            return this;
        }

        public GroupsPageObject RemoveGroup()
        {
            WaitUntil.WaitElement(_webDriver, btnRemove);
            _btnRemove.Click();
            WaitUntil.WaitElement(_webDriver, btnConfirmDeleting);
            _btnConfirmDeleting.Click();
            return new GroupsPageObject(_webDriver);
        }


    }
}
