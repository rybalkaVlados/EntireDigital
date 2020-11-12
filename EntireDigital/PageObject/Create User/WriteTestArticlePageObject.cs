using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntireDigital.PageObject
{
    class WriteTestArticlePageObject
    {
        private IWebDriver _webDriver;


        #region Locators

        private readonly By textBox = By.XPath("//div[@class='note-editable']/p");
        private readonly By countWords = By.XPath("//span[@id='parole_text'][text()='300']");
        private readonly By countCharacters = By.XPath("//span[@id='caratteri_text'][text()='1320']");
        private readonly By bntSend = By.Id("btnSend");
        #endregion

        #region IWebElements
        private IWebElement _textBox => _webDriver.FindElement(textBox);
        private IWebElement _countWords => _webDriver.FindElement(countWords);
        private IWebElement _countCharacters => _webDriver.FindElement(countCharacters);
        private IWebElement _bntSend => _webDriver.FindElement(bntSend);
        #endregion


        public WriteTestArticlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public WriteTestArticlePageObject FillTextBox()
        {
            WaitUntil.WaitElement(_webDriver, textBox);
            var multiplied = string.Join(" ", Enumerable.Repeat(NameForCreateArticle.IFRAME_TEXT, 60).ToArray());
            _textBox.SendKeys(multiplied);
            return this;
        }

        public string GetCountWords()
        {
            string words = _countWords.Text;
            return words;
        }

        public string GetCountCharacters()
        {
            string characters = _countCharacters.Text;
            return characters;
        }

        public SummaryPageObject SendTestArticle()
        {
            _bntSend.Click();
            return new SummaryPageObject(_webDriver);
        }

    }
}
