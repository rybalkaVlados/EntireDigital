using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntireDigital.PageObject;

namespace EntireDigital.PageObject
{
    class GroupsPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By btnCreate = By.CssSelector("a.btn-shadow i.fa");
        private readonly By fieldSearch = By.XPath("//input[@type='search']");
        private readonly By btnShow = By.XPath("//tbody/tr[@role='row']/td[4]/a");
        private readonly By messageEmptyPage = By.XPath("//td[@class='dataTables_empty']");

        #endregion

        #region IWebElements
        private IWebElement _btnCreate => _webDriver.FindElement(btnCreate);
        private IWebElement _fieldSearch => _webDriver.FindElement(fieldSearch);
        private IWebElement _btnShow => _webDriver.FindElement(btnShow);
        private IWebElement _messageEmptyPage => _webDriver.FindElement(messageEmptyPage);
        #endregion


        public GroupsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public FormCreatePageObject CreateButton()
        {
            WaitUntil.WaitElement(_webDriver, btnCreate);
            _btnCreate.Click();
            return new FormCreatePageObject(_webDriver);
        }

        public GroupsPageObject SearchGroup(string nameGroup)
        {
            WaitUntil.WaitElement(_webDriver, fieldSearch);
            _fieldSearch.Clear();
            _fieldSearch.SendKeys(nameGroup);
            return this;
        }

        public DetailsGroupPageObject ClickBtnShow()
        {
            WaitUntil.WaitElement(_webDriver, btnShow);
            _btnShow.Click();
            return new DetailsGroupPageObject(_webDriver);
        }

        public string GetEmptyListGroup()
        {
            string listGroup = _messageEmptyPage.Text;
            return listGroup;
        }

    }
}
