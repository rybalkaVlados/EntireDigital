using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    class CreateTitleForm
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By titleField = By.Id("Title");
        private readonly By categoryField = By.Id("select2-CategoryId-container");
        private readonly By listCategory = By.ClassName("select2-results__option");
        private readonly By buttonAssignToMe = By.Id("btnAssignToMe");

        #endregion

        #region AWebElements
        private IWebElement _titleFielf => _webDriver.FindElement(titleField);
        private IWebElement _categoryField => _webDriver.FindElement(categoryField);
        private IReadOnlyCollection<IWebElement> _listCategory => _webDriver.FindElements(listCategory);
        private IWebElement _buttonAssignToMe => _webDriver.FindElement(buttonAssignToMe);
        #endregion

        public CreateTitleForm(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateTitleForm CreateTitle(string title)
        {
            Thread.Sleep(500);
            _titleFielf.SendKeys(title);

            return this;
        }

        public CreateTitleForm ChoiceElemCategory(string nameElem)
        {
            _categoryField.Click();

            var dropBox = _listCategory.First(x => x.Text == nameElem);
            dropBox.Click();

            return this;
        }

        public WriteArticlePageObject AssignToMe()
        {
            _buttonAssignToMe.Click();
            return new WriteArticlePageObject(_webDriver);
        }



    }
}
