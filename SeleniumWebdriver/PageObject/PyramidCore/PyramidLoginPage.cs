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
   public class PyramidLoginPage:PageBase
    {
        private IWebDriver driver;
       
        #region WebElement
        [FindsBy(How = How.Id, Using = "pydLogin_txtUserid")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "pydLogin_txtUserPwd")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "pydLogin_btnLogin")]
        private IWebElement loginBtn;

        #endregion
        public PyramidLoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public PyramidHomePage LoginToPyramidCore(String Username, String Password)
        {
            username.SendKeys(Username);
            password.SendKeys(Password);
            loginBtn.Click();
            return new PyramidHomePage(driver);
        }

        #endregion
    }
}
