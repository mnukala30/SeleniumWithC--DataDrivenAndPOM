using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject.PyramidCore
{
    public class PyramidHomePage : PageBase
    {
        private IWebDriver driver;
        public PyramidHomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.PartialLinkText, Using = "HelpDesk")]
        private IWebElement helpDesk;

        [FindsBy(How = How.PartialLinkText, Using = "Home")]
        private IWebElement homeLink;
        #endregion

        #region Actions

        public TicketCreationPage clickHelpDeskPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            helpDesk.Click();
            return new TicketCreationPage(driver);


        }
        public void clickHomePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            homeLink.Click();
        }
        #endregion
    }
}
