using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.PageObject.PyramidCore;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.PyramidCore
{
    [TestClass]
    public class TestPyramidTicketCreation
    {
        [TestMethod]
        public void testTicketCreation()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage homePage = new HomePage(ObjectRepository.Driver);
            PyramidLoginPage PloginPage = homePage.NavigateToPyramidLoginPage();
            PyramidHomePage PhomePage= PloginPage.LoginToPyramidCore(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            TicketCreationPage TcPage=PhomePage.clickHelpDeskPage();
            TcPage.createTicket();
            Thread.Sleep(5000);
            TcPage.enterTicketDetails("NMG Hyderabad");

        }


        [TestMethod]
        public void testTicketCreation2()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage homePage = new HomePage(ObjectRepository.Driver);
            PyramidLoginPage PloginPage = homePage.NavigateToPyramidLoginPage();
            PyramidHomePage PhomePage = PloginPage.LoginToPyramidCore(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            TicketCreationPage TcPage = PhomePage.clickHelpDeskPage();
            TcPage.createTicket();
            Thread.Sleep(5000);
            TcPage.enterTicketDetails("NMG Hyderabad");

        }


    }
}
