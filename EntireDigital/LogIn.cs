using EntireDigital.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital
{
    class LogIn
    {
        private IWebDriver _webDriver;



        public LogIn(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorSearchingPageObject LogInAdmin()
        {
            var authPage = new AuthorizationPageObject(_webDriver);
            authPage.LogIn(
                NameVariables.EMAIL_ADMIN,
                NameVariables.PASSWORD_ADMIN);
            return new AuthorSearchingPageObject(_webDriver);
        }

        public AuthorSearchingPageObject LogInEditor()
        {
            var authPage = new AuthorizationPageObject(_webDriver);
            authPage.LogIn(
                NameVariables.EMAIL_EDITOR,
                NameVariables.PASSWORD_EDITOR);
            return new AuthorSearchingPageObject(_webDriver);
        }
    }
}
