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
        private readonly By arrowRight = By.CssSelector("div.btn-select-arrow i.iconfont");
        private readonly By saveButton = By.Id("bntSave");
        private readonly By assignedEditor = By.XPath("//div[@class='transfer-double-selected-list-main']/ul/li/div/label");
        private readonly By profileIcon = By.XPath("//img[@alt='Avatar']");
        private readonly By buttonLogOut = By.LinkText("Logout");
        private readonly By titleID = By.XPath("//div[@class='card-body']/div/div/span[2]/strong");
        #endregion

        #region IWebElements
        private IWebElement _visibility => _webDriver.FindElement(visibility);
        private IReadOnlyCollection<IWebElement> _listAllEditors => _webDriver.FindElements(listAllEditors);
        private IWebElement _arrowRight => _webDriver.FindElement(arrowRight);
        private IWebElement _anacondaEditor => _webDriver.FindElement(anacondaEditor);
        private IWebElement _saveButton => _webDriver.FindElement(saveButton);
        private IWebElement _assignedEditor => _webDriver.FindElement(assignedEditor);
        private IWebElement _profileIcon => _webDriver.FindElement(profileIcon);
        private IWebElement _buttonLogOut => _webDriver.FindElement(buttonLogOut);
        private IWebElement _titleID => _webDriver.FindElement(titleID);
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
            _arrowRight.Click();
            return this;
        }

        public AssignTitlePageObject SaveResult()
        {
            _saveButton.Click();
            return this;
        }

        public AuthorizationPageObject LogOut()
        {
            WaitUntil.WaitSomeInterval(3);
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

        

    }
}
