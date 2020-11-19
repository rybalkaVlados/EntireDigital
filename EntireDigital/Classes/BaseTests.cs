using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EntireDigital
{

    class BaseTest
    {
        #region Global Veriable
        protected IWebDriver _webDriver;

        protected AuthorizationPageObject authorizationPage;
      
        protected Navigation navigate;
        protected YopMailSite yopMailSite;
        protected SignInPageObject signInPage;
        protected WriteTestArticlePageObject testArticle;
        protected SummaryPageObject summaryPage;
        protected CompleteProfileData completeProfilePage;
        protected AuthorSearchingPageObject authorSearchingPage;
        protected EmptyWindow newWindowPage;
        protected AssignTitlePageObject assignPage;
        protected PendingPageObject pendingPage;
        protected ActivePageObject activePage;
        protected FormCreateUser formCreateUserPage;
        protected UserDetails userDetailsPage;
        protected FormCreatePageObject createGroupPage;
        protected GroupsPageObject groupsPage;
        protected DetailsGroupPageObject detailsGroupPage;
        protected WaitingForYouPageObject waitingForYouPage;
        protected DraftsPageObject draftPage;
        protected WriteArticlePageObject writeArticlePage;
        #endregion 

        #region Page Objects
        private void InitPageObjects()
        {            
            authorizationPage = new AuthorizationPageObject(_webDriver);
         
            navigate = new Navigation(_webDriver);
            yopMailSite = new YopMailSite(_webDriver);
            signInPage = new SignInPageObject(_webDriver);
            testArticle = new WriteTestArticlePageObject(_webDriver);
            summaryPage = new SummaryPageObject(_webDriver);
            completeProfilePage = new CompleteProfileData(_webDriver);
            authorSearchingPage = new AuthorSearchingPageObject(_webDriver);
            newWindowPage = new EmptyWindow(_webDriver);
            assignPage = new AssignTitlePageObject(_webDriver);
            pendingPage = new PendingPageObject(_webDriver);
            activePage = new ActivePageObject(_webDriver);
            formCreateUserPage = new FormCreateUser(_webDriver);
            userDetailsPage = new UserDetails(_webDriver);
            createGroupPage = new FormCreatePageObject(_webDriver);
            groupsPage = new GroupsPageObject(_webDriver);
            detailsGroupPage = new DetailsGroupPageObject(_webDriver);
            waitingForYouPage = new WaitingForYouPageObject(_webDriver);
            draftPage = new DraftsPageObject(_webDriver);
            writeArticlePage = new WriteArticlePageObject(_webDriver);
        }
        #endregion 

        [SetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(NameVariables.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil
                .ShouldLocate(_webDriver, NameVariables.URL);

            InitPageObjects();
        }


        [TearDown]
        protected void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
