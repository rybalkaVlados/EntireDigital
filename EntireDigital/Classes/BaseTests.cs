using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EntireDigital
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;

        [SetUp]
        protected void DoBeforeEach()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(NameVariables.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil
                .ShouldLocate(_webDriver, NameVariables.URL);
        }


        [TearDown]
        protected void DoAfterEach()
        {
            _webDriver.Quit();
        }
    }
}
