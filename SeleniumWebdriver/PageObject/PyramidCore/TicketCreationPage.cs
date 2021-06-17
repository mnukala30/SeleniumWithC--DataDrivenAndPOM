using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject.PyramidCore
{
    public class TicketCreationPage : PageBase
    {
        private IWebDriver driver;
        public TicketCreationPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
        #region WebElement
        [FindsBy(How = How.PartialLinkText, Using = "Create Ticket")]
        private IWebElement createTicketLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenu']/div/a[contains(text(),'Create Ticket')]")]
        private IWebElement createTicketSubLink;

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Create Ticket')]")]
        private IWebElement createTicketTable;

        [FindsBy(How = How.XPath, Using = "//select[@pna='Help_Project']")]
        private IWebElement departmentDropDown;

        [FindsBy(How = How.XPath, Using = "//select[@class='inputnormal' and @pna='Help_Module']")]
        private IWebElement relatedWithDropDown;

        [FindsBy(How = How.XPath, Using = "//select[@class='inputnormal' and @pna='Help_TicketType']")]
        private IWebElement ticketTypeDropDown;

        [FindsBy(How = How.XPath, Using = "//select[@class='inputnormal' and @pna='Help_Severity']")]
        private IWebElement severityDropDown;

        [FindsBy(How = How.XPath, Using = "//input[@class='inputnormal' and contains(@name,'txtSubject')]")]
        private IWebElement subjectInput;

        [FindsBy(How = How.XPath, Using = "//body[@id='tinymce']")]
        private IWebElement bodyInput;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'chkCCSupervisor')]")]
        private IWebElement noSupervisorNeeded;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnClear')]")]
        private IWebElement resetButton;
        
        #endregion

        #region Actions

        public void createTicket()
        {

            int size = driver.WindowHandles.Count();
            Console.WriteLine(size);
            if (size > 1)
            {
               
                BrowserHelper.SwitchToWindow(1);
                createTicketLink.Click();
                createTicketSubLink.Click();
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.TextToBePresentInElement(createTicketTable, "Create Ticket"));
                Console.WriteLine("Table is present");
            }
        }

        public void enterTicketDetails(String departmentName)
        {
            SelectElement sel = new SelectElement(departmentDropDown);
            sel.SelectByText(departmentName);

            SelectElement relationType = new SelectElement(relatedWithDropDown);
            relationType.SelectByText("Software Support");

            SelectElement ticketType = new SelectElement(ticketTypeDropDown);
            ticketType.SelectByText("Service Request");

            SelectElement severityType = new SelectElement(severityDropDown);
            severityType.SelectByText("Minor");

            subjectInput.SendKeys("Test ticket creation");
            driver.SwitchTo().Frame(0);
            bodyInput.Click();
            bodyInput.SendKeys("test body");
            driver.SwitchTo().DefaultContent();
            resetButton.Click();
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.TextToBePresentInElement(subjectInput, ""));
            BrowserHelper.SwitchToParent();
           
        }
        #endregion 
    }
}
