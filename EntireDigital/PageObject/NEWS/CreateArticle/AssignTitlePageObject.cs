using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class AssignTitlePageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By visibility = By.XPath("//div[@class='col-md-8']/span[3]/span[2]");
        private readonly By listAllEditors = By.ClassName("transfer-double-list-li");
        private readonly By anacondaEditor = By.XPath("//*[@class='transfer-double-list-main']/ul/li/div/label");
        private readonly By arrowRightUsers = By.CssSelector("div.btn-select-arrow i.iconfont");
        private readonly By arrowRightGroups = By.XPath("//div[@id='tab-groups']/div/div/div/div/div[2]/div[2]/div/i");
        private readonly By saveButton = By.Id("bntSave");
        private readonly By assignedEditor = By.XPath("//div[@class='transfer-double-selected-list-main']/ul/li/div/label");
        private readonly By profileIcon = By.XPath("//img[@alt='Avatar']");
        private readonly By buttonLogOut = By.LinkText("Logout");
        private readonly By titleID = By.XPath("//div[@class='card-body']/div/div/span[2]/strong");
        private readonly By btnGroups = By.Id("btnNavGroups");
        private readonly By fieldSearch = By.CssSelector("#transfer_groups div div.transfer-double-list-search input");
        private readonly By elemWithGroup = By.XPath("//label[text()='Group with user (1 users)']");
        private readonly By elemWithOutGroup = By.XPath("//label[text()='Group without user (0 users)']");
        private readonly By listGroups = By.XPath("//div[@class='checkbox-group']/label");
        #endregion

        #region IWebElements
        private IWebElement _visibility => _webDriver.FindElement(visibility);
        private IReadOnlyCollection<IWebElement> _listAllEditors => _webDriver.FindElements(listAllEditors);
        private IWebElement _arrowRightUsers => _webDriver.FindElement(arrowRightUsers);
        private IWebElement _arrowRightGroups => _webDriver.FindElement(arrowRightGroups);
        private IWebElement _anacondaEditor => _webDriver.FindElement(anacondaEditor);
        private IWebElement _saveButton => _webDriver.FindElement(saveButton);
        private IWebElement _assignedEditor => _webDriver.FindElement(assignedEditor);
        private IWebElement _profileIcon => _webDriver.FindElement(profileIcon);
        private IWebElement _buttonLogOut => _webDriver.FindElement(buttonLogOut);
        private IWebElement _titleID => _webDriver.FindElement(titleID);
        private IWebElement _btnGroups => _webDriver.FindElement(btnGroups);
        private IWebElement _fieldSearch => _webDriver.FindElement(fieldSearch);
        private IWebElement _elemWithGroup => _webDriver.FindElement(elemWithGroup);
        private IWebElement _elemWithOutGroup => _webDriver.FindElement(elemWithOutGroup);
        private IReadOnlyCollection<IWebElement> _listGroups => _webDriver.FindElements(listGroups);
        #endregion

        public AssignTitlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetVisibility()
        {
            WaitUntil.WaitElement(_webDriver, visibility);
            string name = _visibility.Text;
            return name;
        }

        public AssignTitlePageObject ChoiceEditor(string nameElem)
        {
            
            //var listEditors = _listAllEditors.First(x => x.Text == nameElem);
            WaitUntil.WaitElement(_webDriver, listAllEditors);
            _anacondaEditor.Click();
            return this;
        }

        public bool GetAssignedEditor()
        {
            WaitUntil.WaitElement(_webDriver, assignedEditor);
            bool name = _assignedEditor.Displayed;
            return name;
        }

        public AssignTitlePageObject ClickArrowRight()
        {
            WaitUntil.WaitElement(_webDriver, arrowRightUsers);
            _arrowRightUsers.Click();
            return this;
        }

        public AssignTitlePageObject ClickArrowRightGroup()
        {
            WaitUntil.WaitElement(_webDriver, arrowRightGroups);
            _arrowRightGroups.Click();
            return this;
        }

        public AssignTitlePageObject SaveResult()
        {
            _saveButton.Click();
            return this;
        }

        public AuthorizationPageObject LogOut()
        {
            WaitUntil.WaitSomeInterval(4);
            _profileIcon.Click();
            WaitUntil.WaitElement(_webDriver, buttonLogOut);
            _buttonLogOut.Click();
            return new AuthorizationPageObject(_webDriver);
        }

        public string GetTitleID()
        {
            string titleID = _titleID.Text;
            return titleID;
        }

        public AssignTitlePageObject ClickTabGroups()
        {
            _btnGroups.Click();
            return new AssignTitlePageObject(_webDriver);
        }

        public AssignTitlePageObject SearchGroup(string groupName)
        {
            WaitUntil.WaitElement(_webDriver, fieldSearch);
            _fieldSearch.SendKeys(groupName);
            return this;
        }


        public AssignTitlePageObject CheckAllListGroup(string name, string countUsers)
        {
            WaitUntil.WaitSomeInterval();
            var listElem = _listGroups.First(x => x.Text == name + countUsers);

            listElem.Click();
            return this;
        }




        public AssignTitlePageObject CheckBoxWithOutUser()
        {
            WaitUntil.WaitElement(_webDriver, elemWithOutGroup);
            _elemWithOutGroup.Click();
            return this;
        }





    }
}
