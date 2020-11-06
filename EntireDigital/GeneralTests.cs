using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        }

        [Test]
        public void CheckTitle()
        {
            new LogIn(_webDriver)
                .LogInAdmin();
            Assert.AreEqual(_webDriver.Title, NameVariables.DEFAULT_TITLE);
        }

        [Test]
        public void CreateTitle()
        {
            new LogIn(_webDriver)
                .LogInAdmin()
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
        public void CheckManagedTitles()
        {
            new LogIn(_webDriver)
                .LogInAdmin()
                .GoToSummaryPage();

            string managedTitles = new SummaryPageObject(_webDriver)
                .CheckStatistics();
            Assert.AreNotEqual(managedTitles, NameForCreateArticle.ZERO);
        }

       

        [TearDown]
        public void TearDown() 
        {
            _webDriver.Quit();
        }
    }
}