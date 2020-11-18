using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital
{
    class UserCreationByAdmin
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
        public void UserCreationByAdministrator()
        {
            var logIn = new LogIn(_webDriver);
            var navigate = new Navigation(_webDriver);
            var yopMailSite = new YopMailSite(_webDriver);
            var signInPage = new SignInPageObject(_webDriver);
            var testArticle = new WriteTestArticlePageObject(_webDriver);
            var summaryPage = new SummaryPageObject(_webDriver);
            var completeProfilePage = new CompleteProfileData(_webDriver);
            var authPage = new AuthorizationPageObject(_webDriver);
            var newWindowPage = new EmptyWindow(_webDriver);
            var assignePage = new AssignTitlePageObject(_webDriver);
            var logInPage = new LogIn(_webDriver);
            var pendingPage = new PendingPageObject(_webDriver);
            var activePage = new ActivePageObject(_webDriver);
            var formCreateUserPage = new FormCreateUser(_webDriver);
            var userDetailsPage = new UserDetails(_webDriver);



            logIn
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.USERS, NameUsersSection.ACTIVE);
            activePage
                .ClickCreateUser();
            completeProfilePage
                .CompleteDataUpper(
                    NameForCreateUser.FIRST_NAME,
                    NameForCreateUser.LAST_NAME,
                    NameForCreateUser.BIRTH_CITY,
                    NameForCreateUser.BIRTH_DATE);
            formCreateUserPage
                .EnterNecessaryData(
                    NameForCreateUser.PAYPAL_ACCOUNT, 
                    NameForCreateUser.FISCAL_CODE);
            completeProfilePage
                .CompleteDataLower(
                    NameForCreateUser.CITY,
                    NameForCreateUser.ADDRESS,
                    NameForCreateUser.ZIP_CODE,
                    NameForCreateUser.MOBILE_PHONE);
            formCreateUserPage
                .SelectCategories();
            signInPage    
                .OpenNewTab()
                .MoveLastTab();

            newWindowPage
                .GoToURL(NameVariables.URL_YOP);

            yopMailSite
                .GenerateRandomMail();

            string randomMail = yopMailSite
                .GetRandomMail();

            signInPage
                .MoveFirstTab()
                .EnterRandomEmail(randomMail);
            formCreateUserPage
                .SaveResult();

            string actualEmail = userDetailsPage.GetEmail();
            Assert.AreEqual(randomMail, actualEmail);

            userDetailsPage
                .SendCredentials();
          
            signInPage
               .MoveLastTab();
            yopMailSite
                .CheckEmail()
                .GoToFrame(NameVariables.FRAME);

            string getPassword = yopMailSite.GetPassword();

            signInPage
                .MoveFirstTab();

            assignePage
                .LogOut()
                .LogIn(randomMail, getPassword);
            WaitUntil.WaitSomeInterval(10);
        }









        [OneTimeTearDown]
        protected void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
