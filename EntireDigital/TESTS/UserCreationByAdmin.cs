using EntireDigital.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital
{
    class UserCreationByAdmin : BaseTest
    {
        [Test]
        public void UserCreationByAdministrator()
        { 
            authorizationPage
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
            assignPage
                .LogOut()
                .LogIn(randomMail, getPassword);
        }
    }
}
