using OpenQA.Selenium;

namespace EntireDigital.PageObject
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        #region Locators
        private readonly By emailField = By.Name("email");
        private readonly By password = By.Name("password");
        private readonly By submitButton = By.XPath("//button[@type='submit']");
        private readonly By buttonSignIn = By.LinkText("Sign in!");
        #endregion

        #region IWebElements
        private IWebElement _emailField => _webDriver.FindElement(emailField);
        private IWebElement _password => _webDriver.FindElement(password);
        private IWebElement _submitButton => _webDriver.FindElement(submitButton);
        private IWebElement _buttonSignIn => _webDriver.FindElement(buttonSignIn);
        #endregion

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void LogIn(string email, string password)
        {
            WaitUntil.WaitSomeInterval();
            _emailField.SendKeys(email);
            _password.SendKeys(password);
            _submitButton.Click();
        }

        public AuthorSearchingPageObject LogInAdmin()
        {
            LogIn(NameVariables.EMAIL_ADMIN,NameVariables.PASSWORD_ADMIN);
            return new AuthorSearchingPageObject(_webDriver);
        }

        public SummaryPageObject LogInEditor()
        {
            LogIn(NameVariables.EMAIL_EDITOR,NameVariables.PASSWORD_EDITOR);
            return new SummaryPageObject(_webDriver);
        }

        public SignInPageObject GoToSignIn()
        {
            _buttonSignIn.Click();
            return new SignInPageObject(_webDriver);
        }


    }
}
