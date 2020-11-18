using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EntireDigital
{
    class CreateArticleRepeat
    {
        protected IWebDriver _webDriver;

        [SetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(NameVariables.URL);
            WaitUntil
                .ShouldLocate(_webDriver, NameVariables.URL);
        }

        [Test]
        public void CreateTitle()
        {
            for (int i = 0; i < 10; i++)
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
                      .SaveArticle();
                new AssignTitlePageObject(_webDriver).LogOut();
            }
        }

        [TearDown]
        protected void TearDown()
        {
            _webDriver.Quit();
        }

    }
}

