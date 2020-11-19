using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace EntireDigital.PageObject
{
    public class WriteArticlePageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By titleH1Field = By.Id("title");
        private readonly By homePageTitle = By.Id("HomepageTitle");
        private readonly By altTitle = By.Id("AltTitle");
        private readonly By summary = By.Id("Summary");


        private readonly By iFrameText = By.Id("tinymce");

        private readonly By metaTitle = By.Id("SeoTitle");
        private readonly By metaDescription = By.Id("SeoMetaDesc");
        private readonly By slug = By.Id("SeoSlug");
        private readonly By focusKeyPhrase = By.Id("SeoFocusKeyPhrase");

        private readonly By fieldTag = By.Id("Tag");
        private readonly By saveTagButton = By.Id("btnAddTag");
        private readonly By successfulMessage = By.Id("swal2-content");
        private readonly By OKButton = By.CssSelector("div.swal2-actions button.swal2-confirm");

        private readonly By titleImage = By.Id("TitleImg");
        private readonly By alternativeText = By.Id("AltTextImg");
        private readonly By sourceURL = By.Id("SourceUrlImg");
        private readonly By inputImage = By.Id("MainImg");
        private readonly By saveImgButton = By.Id("btnSaveMainImg");

        private readonly By sourceName = By.Id("select2-SourceNameImg-container");
        private readonly By sourceNameList = By.ClassName("select2-results__option");

        private readonly By publishButton = By.LinkText("Save and Publish");
        private readonly By saveAndSendButton = By.LinkText("Save and Send");

        private readonly By confirmButton = By.Id("btnPublish");
        private readonly By confirmSendButton = By.Id("btnSend");

        private readonly By getArticleID = By.XPath("//div[@class='col-md-8']/span[2]/strong");
        private readonly By btnSave = By.Id("btnSaveArticle");



        #endregion

        #region IWebElements
        private IWebElement _titleH1Fielf => _webDriver.FindElement(titleH1Field);
        private IWebElement _homePageTitle => _webDriver.FindElement(homePageTitle);
        private IWebElement _altTitle => _webDriver.FindElement(altTitle);
        private IWebElement _summary => _webDriver.FindElement(summary);

        private IWebElement _iFrameText => _webDriver.FindElement(iFrameText);

        private IWebElement _metaTitle => _webDriver.FindElement(metaTitle);
        private IWebElement _metaDescription => _webDriver.FindElement(metaDescription);
        private IWebElement _slug => _webDriver.FindElement(slug);
        private IWebElement _focusKeyPhrase => _webDriver.FindElement(focusKeyPhrase);

        private IWebElement _fieldTag => _webDriver.FindElement(fieldTag);
        private IWebElement _saveTagButton => _webDriver.FindElement(saveTagButton);
        private IWebElement _successfulMessage => _webDriver.FindElement(successfulMessage);
        private IWebElement _OKButton => _webDriver.FindElement(OKButton);

        private IWebElement _titleImage => _webDriver.FindElement(titleImage);
        private IWebElement _alternativeText => _webDriver.FindElement(alternativeText);
        private IWebElement _sourceURL => _webDriver.FindElement(sourceURL);
        private IWebElement _inputImage => _webDriver.FindElement(inputImage);
        private IWebElement _saveImgButton => _webDriver.FindElement(saveImgButton);

        private IWebElement _sourceName => _webDriver.FindElement(sourceName);
        private IReadOnlyCollection<IWebElement> _sourceNameList => _webDriver.FindElements(sourceNameList);

        private IWebElement _publishButton => _webDriver.FindElement(publishButton);
        private IWebElement _saveAndSendButton => _webDriver.FindElement(saveAndSendButton);

        private IWebElement _confirmButton => _webDriver.FindElement(confirmButton);
        private IWebElement _confirmSendButton => _webDriver.FindElement(confirmSendButton);

        private IWebElement _getArticleID => _webDriver.FindElement(getArticleID);
        private IWebElement _btnSave => _webDriver.FindElement(btnSave);



        #endregion


        private Random _random = new Random();


        public WriteArticlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public WriteArticlePageObject WriteArticleUpper(string titleH1, string homeTitle, string altTitle, string summary)
        {
            WaitUntil.WaitElement(_webDriver, titleH1Field);
            _titleH1Fielf.SendKeys(titleH1);
            _homePageTitle.SendKeys(homeTitle);
            _altTitle.SendKeys(altTitle);
            _summary.SendKeys(summary);
            return this;
        }

        public WriteArticlePageObject FillIFrame(string iframeID)
        {
            var multiplied = string.Join(" ", Enumerable.Repeat(NameForCreateArticle.IFRAME_TEXT, 60).ToArray());

            _webDriver.SwitchTo().Frame(iframeID);                     //start Iframe
            _iFrameText.SendKeys(multiplied);
            _webDriver.SwitchTo().DefaultContent();                    //finish Iframe

            return this;
        }

        public WriteArticlePageObject WriteArticleLower(string metaText, string metaDesc, string slug, string focusKey)
        {
            WaitUntil.WaitElement(_webDriver, metaTitle);
            _metaTitle.SendKeys(metaText);
            _metaDescription.SendKeys(metaDesc);
            _slug.Clear();
            _slug.SendKeys(slug);

            int randomNumber = _random.Next(0, 9999999);
            _focusKeyPhrase.SendKeys(focusKey + randomNumber);

            return this;
        }

        public WriteArticlePageObject AddTag(string tag)
        {
            WaitUntil.WaitElement(_webDriver, fieldTag);
            _fieldTag.SendKeys(tag);
            _fieldTag.SendKeys(Keys.Enter);
            _saveTagButton.Click();

            return this;
        }

        public WriteArticlePageObject AssertPopUp(string getResult)
        {
            WaitUntil.WaitElement(_webDriver, successfulMessage);
            Assert.AreEqual(_successfulMessage.Text, getResult);
            _OKButton.Click();

            return this;
        }

        public WriteArticlePageObject AddInfoImage(string title, string altText, string sourceURL)
        {
            _titleImage.SendKeys(title);
            _alternativeText.SendKeys(altText);
            _sourceURL.SendKeys(sourceURL);

            return this;
        }

        public WriteArticlePageObject AddImage(string imagePuth)
        {
            _inputImage.SendKeys(imagePuth);
            _saveImgButton.Click();

            return this;
        }

        public WriteArticlePageObject ChoiceSourceName(string nameElem)
        {
            WaitUntil.WaitElement(_webDriver, sourceName);
            _sourceName.Click();
            var dropBox = _sourceNameList.First(x => x.Text == nameElem);
            dropBox.Click();

            return this;
        }
        public WriteArticlePageObject ScrollTopPage(string script)
        {
            var jse = (IJavaScriptExecutor)_webDriver;
            jse.ExecuteScript(script);

            return this;
        }


        public WriteArticlePageObject SaveAndSendArticle()
        {
            WaitUntil.WaitSomeInterval();
            _saveAndSendButton.Click();

            WaitUntil.WaitElement(_webDriver, confirmSendButton);
            _confirmSendButton.Click();

            return this;
        }
        public WriteArticlePageObject PublishArticle()
        {
            WaitUntil.WaitSomeInterval();
            _publishButton.Click();

            WaitUntil.WaitElement(_webDriver, confirmButton);
            _confirmButton.Click();

            WaitUntil.WaitSomeInterval(15);
            return this;
        }

        public string GetArticleID()
        {
            string articleID = _getArticleID.Text;
            return articleID;
        }

        public WriteArticlePageObject SaveArticle()
        {
            WaitUntil.WaitSomeInterval(2);
            _btnSave.Click();
            WaitUntil.WaitElement(_webDriver, OKButton);
            _OKButton.Click();
            return this;
        }


    }
}