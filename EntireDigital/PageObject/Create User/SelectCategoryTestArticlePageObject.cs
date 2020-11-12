using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntireDigital.PageObject
{
    class SelectCategoryTestArticlePageObject
    {
        private IWebDriver _webDriver;

        private readonly By listCategory = By.XPath("//div[@class='form-group']/span/span/span");
        private readonly By choiceCategory = By.ClassName("select2-results__option");
        private readonly By btnStart = By.XPath("//button[@type='submit']");

        private IWebElement _listCategory => _webDriver.FindElement(listCategory);
        private IReadOnlyCollection<IWebElement> _choiceCategory => _webDriver.FindElements(choiceCategory);
        private IWebElement _btnStart => _webDriver.FindElement(btnStart);

        public SelectCategoryTestArticlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SelectCategoryTestArticlePageObject ChoiceElemCategory(string nameElem)
        {
            WaitUntil.WaitElement(_webDriver, listCategory);
            _listCategory.Click();

            var dropBox = _choiceCategory.First(x => x.Text == nameElem);
            WaitUntil.WaitElement(_webDriver, choiceCategory);
            dropBox.Click();

            return new SelectCategoryTestArticlePageObject(_webDriver);
        }

        public WriteTestArticlePageObject ClickStart()
        {
            _btnStart.Click();
            return new WriteTestArticlePageObject(_webDriver);
        }

    }

}
