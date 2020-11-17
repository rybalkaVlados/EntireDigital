using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntireDigital.PageObject
{
    class DetailsGroupPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By dropList = By.CssSelector("span.selection span.select2-selection");
        private readonly By listUsers = By.ClassName("select2-results__option");
        private readonly By btnAdd = By.CssSelector("div.col-md-6 button.btn");
        private readonly By getUser = By.XPath("//table[@id='example']/tbody/tr/td[1]");
        private readonly By fieldSearch = By.XPath("//input[@type='search']");
        private readonly By btnEdit = By.CssSelector("div.card-body div.row div.col-md-4 a.btn");
        private readonly By btnDeleteUser = By.XPath("//table[@id='example']/tbody/tr/td[2]/a/i");
        private readonly By btnConfirmDeleting = By.XPath("//button[text()='Remove']");


        #endregion

        #region IWebElements
        private IWebElement _dropList => _webDriver.FindElement(dropList);
        private IReadOnlyCollection<IWebElement> _listUsers => _webDriver.FindElements(listUsers);
        private IWebElement _btnAdd => _webDriver.FindElement(btnAdd);
        private IWebElement _getUser => _webDriver.FindElement(getUser);
        private IWebElement _fieldSearch => _webDriver.FindElement(fieldSearch);
        private IWebElement _btnEdit => _webDriver.FindElement(btnEdit);
        private IWebElement _btnDeleteUser => _webDriver.FindElement(btnDeleteUser);
        private IWebElement _btnConfirmDeleting => _webDriver.FindElement(btnConfirmDeleting);
        #endregion


        public DetailsGroupPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public DetailsGroupPageObject AddUsersInGroup(string nameElem)
        {
            WaitUntil.WaitElement(_webDriver, dropList);
            _dropList.Click();

            WaitUntil.WaitElement(_webDriver, listUsers);
            var dropBox = _listUsers.First(x => x.Text == nameElem);
            WaitUntil.WaitElement(_webDriver, listUsers);
            dropBox.Click();
            _btnAdd.Click();
            return this;
        }

        public DetailsGroupPageObject SearchUser(string userName)
        {
            WaitUntil.WaitElement(_webDriver, fieldSearch);
            _fieldSearch.SendKeys(userName);
            return this;
        }


        public string GetActualUserName()
        {
            WaitUntil.WaitElement(_webDriver, getUser);
            string name = _getUser.Text;
            return name;
        }

        public DetailsGroupPageObject DeleteUser()
        {
            WaitUntil.WaitElement(_webDriver, btnDeleteUser);
            _btnDeleteUser.Click();
            WaitUntil.WaitElement(_webDriver, btnConfirmDeleting);
            _btnConfirmDeleting.Click();
            return this;
        }

        public FormCreatePageObject ClickEdit()
        {
            _btnEdit.Click();
            return new FormCreatePageObject(_webDriver);
        }
    }
}