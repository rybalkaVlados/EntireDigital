using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection.Metadata;
using System.Threading;

namespace EntireDigital
{
    public class Tests
    {
        protected IWebDriver _webDriver;


        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(NameVariables.URL);
            _webDriver.Manage().Window.Maximize();

            var authPage = new AuthorizationPageObject(_webDriver);
            authPage.LogIn(
                NameVariables.EMAIL_ADMIN,
                NameVariables.PASSWORD_ADMIN);
        }

        [Test]
        public void GetTitle()
        {
            Assert.AreEqual(_webDriver.Title, NameVariables.DEFAULT_TITLE);
            Thread.Sleep(5000);
        }

        [Test]
        public void CreateTitle()
        {
            var authSearching = new AuthorSearchingPageObject(_webDriver);
            authSearching
                .CreateButton()
                .CreateTitle(NameForCreateArticle.TITLE)
                .ChoiceElemCategory(NameForCreateArticle.CATEGORY_NERA)
                .AssignToMe()
                .WriteArticleUpper(
                NameForCreateArticle.TITLE_H1,
                NameForCreateArticle.HOME_TITLE,
                NameForCreateArticle.ALT_TITLE,
                NameForCreateArticle.SUMMARY)
                .FillIFrame(NameForCreateArticle.IFRAME)
                .WriteArticleLower(
                NameForCreateArticle.META_TITLE,
                NameForCreateArticle.DESCRIPTION_TITLE,
                NameForCreateArticle.SLUG,
                NameForCreateArticle.FOCUS_KEY)
                .AddTag(NameForCreateArticle.FIRST_TAG)
                .AssertPopUp(NameForCreateArticle.ER_AFTER_ADD_TAG)
                .AddTag(NameForCreateArticle.SECOND_TAG)
                .AssertPopUp(NameForCreateArticle.ER_AFTER_ADD_TAG)
                .ChoiceSourceName(NameForCreateArticle.SOURCE_NAME_ELEM)
                .AddInfoImage(
                NameForCreateArticle.TITLE,
                NameForCreateArticle.ALT_TITLE,
                NameForCreateArticle.SOURCE_URL)
                .AddImage(NameForCreateArticle.PUTH_IMAGE)
                .AssertPopUp(NameForCreateArticle.ER_AFTER_ADD_IMAGE)
                .ScrollTopPage(NameForCreateArticle.SCRIPT)
                .PublishArticle();
                




            Thread.Sleep(5000);
        }
        [Test]
        public void testQA()
        {
            _webDriver.Navigate().GoToUrl("https://stackoverrun.com/ru/q/5064559");
            _webDriver.FindElement(By.XPath("//div[@id='41335111']/div/div/span[2]/i")).Click();
            Thread.Sleep(3000);
            var jse = (IJavaScriptExecutor)_webDriver;

            // The minified JavaScript to execute
            const string script =
                "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            // Start Scrolling
            jse.ExecuteScript(script);
            Thread.Sleep(10000);
        }

       

        [TearDown]
        public void TearDown() 
        {
            _webDriver.Quit();
        }
    }
}