using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntireDigital.PageObject
{
    public class Navigation
    {
        #region Locators
        private readonly By sideBarSummary = By.XPath("//a[@title='Summary']");
        private readonly By sideBarNews = By.XPath("//a[@title='News']");
        private readonly By sideBarUsers = By.XPath("//a[@title='Users']");
        private readonly By sideBarContents = By.XPath("//a[@title='Contents']");
        private readonly By sideBarCategories = By.XPath("//a[@title='Categories/Tags']");
        private readonly By sideBarGroups = By.XPath("//a[@title='Groups']");
        private readonly By sideBarCashFlows = By.XPath("//a[@title='Cash Flows']");
        private readonly By sideBarUsersStats = By.XPath("//a[@title='Users Stats']");
        private readonly By sideBarStaff = By.XPath("//a[@title='Staff']");
        private readonly By sideBarFees = By.XPath("//a[@title='Fees']");
        private readonly By sideBarPayments = By.XPath("//a[@title='Payments']");

        private readonly By checkDisplayNews = By.XPath("//a[@title='News'][@aria-expanded]");
        private readonly By checkDisplayUsers = By.XPath("//a[@title='Users'][@aria-expanded]");
        private readonly By checkDisplayContents = By.XPath("//a[@title='Contents'][@aria-expanded]");
        private readonly By checkDisplayCategories = By.XPath("//a[@title='Categories/Tags'][@aria-expanded]");

        private readonly By listPages = By.XPath("//a[@style='font-weight:normal;']");
        #endregion

        #region IWebElements
        private IWebElement _sideBarSummary => _webDriver.FindElement(sideBarSummary);
        private IWebElement _sideBarGroups => _webDriver.FindElement(sideBarGroups);
        private IWebElement _sideBarNews => _webDriver.FindElement(sideBarNews);
        private IWebElement _sideBarUsers => _webDriver.FindElement(sideBarUsers);
        private IWebElement _sideBarContents => _webDriver.FindElement(sideBarContents);
        private IWebElement _sideBarCategories => _webDriver.FindElement(sideBarCategories);
        private IWebElement _sideBarCashFlows => _webDriver.FindElement(sideBarCashFlows);
        private IWebElement _sideBarUsersStats => _webDriver.FindElement(sideBarUsersStats);
        private IWebElement _sideBarStaff => _webDriver.FindElement(sideBarStaff);
        private IWebElement _sideBarFees => _webDriver.FindElement(sideBarFees);
        private IWebElement _sideBarPayments => _webDriver.FindElement(sideBarPayments);

        private IWebElement _checkDisplayNews => _webDriver.FindElement(checkDisplayNews);
        private IWebElement _checkDisplayUsers => _webDriver.FindElement(checkDisplayUsers);
        private IWebElement _checkDisplayContents => _webDriver.FindElement(checkDisplayContents);
        private IWebElement _checkDisplayCategories => _webDriver.FindElement(checkDisplayCategories);
    
        private IReadOnlyCollection<IWebElement> _listPages => _webDriver.FindElements(listPages);
        #endregion

        #region Constructor
        private IWebDriver _webDriver;

        public Navigation(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        #endregion

        private bool CheckVisibilityElement(IWebElement element)
        {
            try
            {
                bool elem = element.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private void ChoiceElemSideBar(string namePage)
        {
            WaitUntil.WaitSomeInterval();
            var list = _listPages.First(x => x.Text == namePage);
            WaitUntil.WaitElement(_webDriver, listPages);
            list.Click();
        }

        public void GoToPageNewsSection(string nameSection, string namePage = null)
        {
            if (nameSection == NameSections.NEWS)
            {
                try
                {
                    if (CheckVisibilityElement(_checkDisplayNews) == true)
                    {
                        ChoiceElemSideBar(namePage);
                    }
                }
                catch
                {
                    WaitUntil.WaitSomeInterval();
                    _sideBarNews.Click();
                    ChoiceElemSideBar(namePage);
                }

            }
            else if (nameSection == NameSections.USERS)
            {
                try
                {
                    if (CheckVisibilityElement(_checkDisplayUsers) == true)
                    {
                        ChoiceElemSideBar(namePage);
                    }
                }
                catch
                {
                    WaitUntil.WaitSomeInterval();
                    _sideBarUsers.Click();
                    ChoiceElemSideBar(namePage);
                }
            }
            else if (nameSection == NameSections.CONTENTS)
            {
                try
                {
                    if (CheckVisibilityElement(_checkDisplayContents) == true)
                    {
                        ChoiceElemSideBar(namePage);
                    }
                }
                catch
                {
                    WaitUntil.WaitSomeInterval();
                    _sideBarContents.Click();
                    ChoiceElemSideBar(namePage);
                }
            }
            else if (nameSection == NameSections.CATEGORIES)
            {
                try
                {
                    if (CheckVisibilityElement(_checkDisplayCategories) == true)
                    {
                        ChoiceElemSideBar(namePage);
                    }
                }
                catch
                {
                    WaitUntil.WaitSomeInterval();
                    _sideBarCategories.Click();
                    ChoiceElemSideBar(namePage);
                }
            }
            else if (nameSection == NameSections.SUMMARY)
            {
                _sideBarSummary.Click();
            }
            else if (nameSection == NameSections.CASH_FLOWS)
            {
                _sideBarCashFlows.Click();
            }
            else if (nameSection == NameSections.USERS_STATS)
            {
                _sideBarUsersStats.Click();
            }
            else if (nameSection == NameSections.GROUPS)
            {
                _sideBarGroups.Click();
            }
            else if (nameSection == NameSections.STAFF)
            {
                _sideBarStaff.Click();
            }
            else if (nameSection == NameSections.FEES)
            {
                _sideBarFees.Click();
            }
            else if (nameSection == NameSections.PAYMENTS)
            {
                _sideBarPayments.Click();
            }
        }

    }
}
