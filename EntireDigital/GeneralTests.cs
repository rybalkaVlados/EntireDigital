using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.Net;
using System.Threading;

namespace EntireDigital
{
    [TestFixture]
    public class GeneralTest : BaseTest
    {



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
            /*    
                .PublishArticle();
            string expectedID = new WriteArticlePageObject(_webDriver).GetArticleID();

            new SummaryPageObject(_webDriver)
                .GoToPublished();

            string actualID = new WaitingForYouPageObject(_webDriver).CheckTitleID();
            Assert.AreEqual(expectedID, actualID); */
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

        [Test]
        public void CreateEditor()
        {
            var yopMailSite = new YopMailSite(_webDriver);
            var signInPage = new SignInPageObject(_webDriver);
            var testArticle = new WriteTestArticlePageObject(_webDriver);
            var summaryPage = new SummaryPageObject(_webDriver);
            var completeProfilePage = new CompleteProfileData(_webDriver);
            var authPage = new AuthorizationPageObject(_webDriver);
            var newWindowPage = new EmptyWindow(_webDriver);
            var assignePage = new AssignTitlePageObject(_webDriver);
            var logInPage = new LogIn(_webDriver);


            authPage
                .GoToSignIn()
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
                .CloseWelcomMessage()
                .EnterRandomEmail(randomMail)
                .EnterTwoPassword(NameVariables.PASSWORD_EDITOR, NameVariables.PASSWORD_EDITOR)
                .ClickCheckBox()
                .Register();

            Assert.NotNull(signInPage.CheckWelcomeMessage());

            signInPage
                .MoveLastTab();
            yopMailSite
                .CheckEmail()
                .ValidateEmail(NameVariables.FRAME);
            signInPage
                .MoveLastTab();

            completeProfilePage
                .CompleteDataUpper(
                NameForCreateUser.FIRST_NAME,
                NameForCreateUser.LAST_NAME,
                NameForCreateUser.BIRTH_CITY,
                NameForCreateUser.BIRTH_DATE)
                .CompleteDataLower(
                NameForCreateUser.CITY,
                NameForCreateUser.ADDRESS,
                NameForCreateUser.ZIP_CODE,
                NameForCreateUser.MOBILE_PHONE)
                .GoWriteTestArticle()
                .ChoiceElemCategory(NameForCreateArticle.CATEGORY_CRONACA)
                .ClickStart()
                .FillTextBox();

            string countWords = testArticle
                .GetCountWords();
            Assert.NotNull(countWords);

            string countCharacters = testArticle
                .GetCountCharacters();
            Assert.NotNull(countCharacters);

            testArticle
                .SendTestArticle();

            string fullName = summaryPage
                .GetFullName();

            string textEvaluating = summaryPage
                .GetEvaluatingText();

            Assert.AreEqual(textEvaluating, NameForCreateArticle.TEXT_EVALUATING);

            assignePage
                .LogOut();

            logInPage
                .LogInAdmin()
                .GoToUsersPage()
                .GoToPendingPage()
                .SearchTestArticle(fullName)
                .ApproveTestArticle();

            //  Thread.Sleep(100000000);
        }










    }
}