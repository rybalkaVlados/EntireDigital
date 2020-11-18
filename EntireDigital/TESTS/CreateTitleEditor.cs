using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EntireDigital
{
    class CreateTitleEditor
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(NameVariables.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil
                .ShouldLocate(_webDriver, NameVariables.URL);
        }


        [Test]
        public void Authorization()
        {
            new LogIn(_webDriver)
                .LogInAdmin();
            Assert.AreEqual(_webDriver.Title, NameVariables.DEFAULT_TITLE);
        }

        [Test]
        public void CreateTitleForEsteriBlog()
        {
            new AuthorSearchingPageObject(_webDriver)
                .CreateButton();

            string getSiteName = new CreateTitlePageObject(_webDriver).GetEsteriBlog();
            Assert.AreEqual(getSiteName, NameForCreateArticle.RED_ESTERI_BLOG_TEST_TEXT);
        }

        [Test]
        public void DataTitle()
        {
            var assignPage = new CreateTitlePageObject(_webDriver)
                .CreateTitle(NameForCreateArticle.TITLE)
                .ChoiceElemCategory(NameForCreateArticle.CATEGORY_NERA)
                .SaveAndAssign();
            
            Assert.AreEqual(assignPage.GetVisibility(), NameForCreateArticle.INVISIBLE_STATUS);
        }

        [Test]
        public void EditorAssign()
        {
            var assignPage = new AssignTitlePageObject(_webDriver);
            var navigate = new Navigation(_webDriver);



            assignPage
                .ChoiceEditor(NameForCreateArticle.ANACONDA_EDITOR)
                .ClickArrowRight();

            bool assignedEditor = assignPage.GetAssignedEditor();
            Assert.IsTrue(assignedEditor);
            

            string expectedID = assignPage.GetTitleID();
            Assert.NotNull(expectedID);
            

            assignPage.SaveResult();
            Assert.AreEqual(assignPage.GetVisibility(), NameForCreateArticle.VISIBLE_STATUS);

            assignPage.LogOut();


            new LogIn(_webDriver)
                .LogInEditor();
            WaitUntil.WaitSomeInterval(2);
            Assert.AreEqual(NameVariables.DEFAULT_TITLE_EDITOR, _webDriver.Title);


            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.WAITING_FOR_YOU);
            WaitUntil.WaitSomeInterval(8);
            string actualID = new WaitingForYouPageObject(_webDriver).CheckTitleID();
            Assert.AreEqual(expectedID, actualID);
        

        
            new WaitingForYouPageObject(_webDriver)
                .GetItArticle()
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
                .SaveAndSendArticle();
            new AssignTitlePageObject(_webDriver)
                .LogOut();
            new LogIn(_webDriver)
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.DRAFTS);
            Assert.AreEqual(expectedID, actualID);
            new DraftsPageObject(_webDriver)
                .CheckArticle()
                .PublishArticle();
            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.PUBLISHED);
            Assert.AreEqual(expectedID, actualID);           
        }





        [OneTimeTearDown]
        protected void Z_TearDown()
        {
            _webDriver.Quit();
        }
    }
}
