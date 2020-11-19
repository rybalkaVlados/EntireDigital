using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;


namespace EntireDigital
{
    [TestFixture]
    class GeneralTest : BaseTest
    {
        
        [Test]
        public void CheckTitle()
        {
            authorizationPage
                .LogInAdmin();
            Assert.AreEqual(_webDriver.Title, NameVariables.DEFAULT_TITLE);
        }

        [Test]
        public void CreateTitle()
        {
            authorizationPage
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
            string expectedID = writeArticlePage.GetArticleID();

            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.PUBLISHED);


            string actualID = waitingForYouPage.CheckTitleID();
            Assert.AreEqual(expectedID, actualID);
        }


        [Test]
        public void CheckManagedTitles()
        {
            authorizationPage
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.SUMMARY);

            string managedTitles = summaryPage.CheckStatistics();
            Assert.AreNotEqual(managedTitles, NameForCreateArticle.ZERO);
        }

        [Test]
        public void CreateEditor()
        {
            authorizationPage
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
                .GoToFrame(NameVariables.FRAME)
                .ValidateEmail();
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
                .ClickSave()
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

            assignPage
                .LogOut();

            authorizationPage
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.USERS, NameUsersSection.PENDING);
            pendingPage
                .SearchTestArticle(fullName)
                .ApproveTestArticle();
        }

        [Test]
        public void CreateGroup()
        {
            string groupWithUser = createGroupPage.RandomNameGroup();
            string groupWithOutUser = createGroupPage.RandomNameGroup();

            authorizationPage
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.GROUPS);
            groupsPage
                .CreateButton()
                .CreateGroup(groupWithUser, NameForCreteGroup.DESCRIPTION)
                .AddUsersInGroup(NameForCreteGroup.NAME_ANACONDA)
                .SearchUser(NameForCreteGroup.NAME_ANACONDA);

            string actualName = detailsGroupPage.GetActualUserName();
            Assert.AreEqual(actualName, NameForCreteGroup.NAME_ANACONDA);

            detailsGroupPage
                .ClickEdit()
                .MakeGroupActive();
            navigate
                .GoToPageNewsSection(NameSections.GROUPS);
            groupsPage
                .CreateButton()
                .CreateGroup(groupWithOutUser, NameForCreteGroup.DESCRIPTION)
                .ClickEdit()
                .MakeGroupActive();

            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.AUTHOR_SEARCHING);

            authorSearchingPage
                .CreateButton()
                .CreateTitle(groupWithUser)
                .ChoiceElemCategory(NameForCreateArticle.CATEGORY_ECONOMIA)
                .SaveAndAssign()
                .ClickTabGroups()
                .SearchGroup(groupWithUser)
                .CheckAllListGroup(groupWithUser, NameForCreteGroup.ONE_USER)
                .ClickArrowRightGroup()
                .SaveResult();
            bool assignedEditor = assignPage.GetAssignedEditor();
            Assert.IsTrue(assignedEditor);
            string titleIdWith = assignPage.GetTitleID();

            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.AUTHOR_SEARCHING);
            authorSearchingPage
                .CreateButton()
                .CreateTitle(groupWithOutUser)
                .ChoiceElemCategory(NameForCreateArticle.CATEGORY_POLITICA)
                .SaveAndAssign()
                .ClickTabGroups()
                .SearchGroup(groupWithOutUser)
                .CheckAllListGroup(groupWithOutUser, NameForCreteGroup.ZERO_USERS)
                .ClickArrowRightGroup()
                .SaveResult();
            Assert.IsTrue(assignedEditor);
            string titleIdWithOut = assignPage.GetTitleID();

            assignPage
                .LogOut();
            authorizationPage
                .LogInEditor();
            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.WAITING_FOR_YOU);


            string actualId = waitingForYouPage.CheckTitleID();
            Assert.AreEqual(actualId, titleIdWith);
            Assert.AreNotEqual(actualId, titleIdWithOut);

            waitingForYouPage
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
            assignPage
                .LogOut();
            authorizationPage
                .LogInAdmin();
            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.DRAFTS);
            Assert.AreEqual(actualId, titleIdWith);
            draftPage
                .CheckArticle()
                .PublishArticle();
            navigate
                .GoToPageNewsSection(NameSections.NEWS, NameNewsSection.PUBLISHED);
            Assert.AreEqual(actualId, titleIdWith);
            navigate
                .GoToPageNewsSection(NameSections.GROUPS);
            groupsPage
                .SearchGroup(groupWithUser)
                .ClickBtnShow()
                .DeleteUser()
                .ClickEdit()
                .RemoveGroup()
                .SearchGroup(groupWithUser);

            string notFoundGroup = groupsPage.GetEmptyListGroup();
            Assert.AreEqual(notFoundGroup, NameForCreteGroup.NO_FOUND_GROUP);

            groupsPage
                .SearchGroup(groupWithOutUser)
                .ClickBtnShow()
                .ClickEdit()
                .RemoveGroup()
                .SearchGroup(groupWithOutUser);

            Assert.AreEqual(notFoundGroup, NameForCreteGroup.NO_FOUND_GROUP);
        }
    }
}