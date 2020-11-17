using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class CreateTitlePageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By titleField = By.Id("Title");
        private readonly By categoryField = By.Id("select2-CategoryId-container");
        private readonly By listCategory = By.ClassName("select2-results__option");
        private readonly By buttonAssignToMe = By.Id("btnAssignToMe");
        private readonly By nameSite = By.CssSelector("div.col-md-12 strong.text-blue-project");
        private readonly By buttonSaveAndAssign = By.Id("btnAssign");

        #endregion

        #region AWebElements
        private IWebElement _titleFielf => _webDriver.FindElement(titleField);
        private IWebElement _categoryField => _webDriver.FindElement(categoryField);
        private IReadOnlyCollection<IWebElement> _listCategory => _webDriver.FindElements(listCategory);
        private IWebElement _buttonAssignToMe => _webDriver.FindElement(buttonAssignToMe);
        private IWebElement _nameSite => _webDriver.FindElement(nameSite);
        private IWebElement _buttonSaveAndAssign => _webDriver.FindElement(buttonSaveAndAssign);
        #endregion

        public CreateTitlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateTitlePageObject CreateTitle(string title)
        {
            Thread.Sleep(500);
            _titleFielf.SendKeys(title);

            return this;
        }

        public CreateTitlePageObject ChoiceElemCategory(string nameElem)
        {
            WaitUntil.WaitElement(_webDriver, categoryField);
            _categoryField.Click();

            var dropBox = _listCategory.First(x => x.Text == nameElem);
            WaitUntil.WaitElement(_webDriver, listCategory);
            dropBox.Click();

            return this;
        }

        public WriteArticlePageObject AssignToMe()
        {
            _buttonAssignToMe.Click();
            return new WriteArticlePageObject(_webDriver);
        }

        public AssignTitlePageObject SaveAndAssign()
        {
            _buttonSaveAndAssign.Click();
            return new AssignTitlePageObject(_webDriver);
        }



        public string GetEsteriBlog()
        {
            string name = _nameSite.Text;
            return name;
        }
    }
}
