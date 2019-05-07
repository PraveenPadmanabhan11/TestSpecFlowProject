using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using TechTalk.SpecFlow;
using System.Configuration;
 

namespace TestNunitDemo
{
    public class Page
    {
        public static IWebDriver driver;
        private string UserNameTB_Xpath = "Xpath~//input[@id='user_login']";
        private string PasswordTB_Xpath = "Xpath~//input[@id='user_pass']";
        private string LoginBtn_Xpath = "Xpath~//input[@id='wp-submit']";
        private string PagesLink_Xpath = "Xpath~//li[@id='menu-pages']//div[contains(.,'Pages')]";
        private string PagesHeaderText_Xpath = "Xpath~//h1[@class='wp-heading-inline']";
        private string AddNewBtn_LinkText= "LinkText~Add New";
        private string AddNewPagesHeaderText_Xpath = "Xpath~//h1[contains(.,'Add New Page')]";
        private string AddPageTitleTB_ID = "Id~title";
        private string AddPageSaveDraftBtn_ID = "Id~save-post";
        private string AddPagePublishBtn_ID = "Id~publish";
        private string PagePublishedMessage_Xpath = "Xpath~//div[@id='message']//p[contains(.,'Page published')]";
        private string PageDraftSavedMessage_Xpath = "Xpath~//div[@id='message']//p[contains(.,'Page draft updated')]";
        private string AllPages_LinkText = "LinkText~All Pages";
        private string SavePagesAsDraft_ID = "Id~save-post";
        private string PublishedPagesCount_Xapth = "Xpath~//li[@class='publish']//span[@class='count']";
        private string SavedPagesCount_Xpath = "Xpath~//li[@class='draft']//span[@class='count']";
        private string LoginError_Id = "Id~login_error";
        protected string URL = ConfigurationManager.AppSettings["URL"];
        protected string driverOptions = ConfigurationManager.AppSettings["browser"];

        WebDriverWait driverWait;
        protected Utils utils = new Utils();

        public Page()
        {
        }

        public void navigateToURL()
        {
            driver = utils.instantiateDriver(driverOptions);
            utils.navigateTo(driver,URL);
        }
        public void enterUserName(string userName)
        {
            ScenarioContext.Current["userNameValue"] = userName;
            utils.sendText(utils.getElement(driver, UserNameTB_Xpath), userName);
        }

        public void enterPassword(string password)
        {
            utils.sendText(utils.getElement(driver, PasswordTB_Xpath), password);
        }

        public void clickLogin()
        {
            utils.click(utils.getElement(driver, LoginBtn_Xpath));
        }

        public bool AssertTheLandingPage(string assertionCondition)
        {
            string name = (string)ScenarioContext.Current["userNameValue"];
            if (assertionCondition.Equals("True"))
                return utils.elementIsDisplayed(driver,utils.getElement(driver, "Xpath~//li[@id='wp-admin-bar-my-account']//span[contains(.,'" + name + "')]"));
            else
                return utils.elementIsDisplayed(driver, utils.getElement(driver, LoginError_Id));
        }

        public bool navigateToPages()
        {
            utils.click(utils.getElement(driver, PagesLink_Xpath));
            string pageHeader = utils.getText(driver, utils.getElement(driver, PagesHeaderText_Xpath));
            if (pageHeader.Equals("Pages"))
                return true;
            else
                return false;
        }

        public void clickAddNewPage()
        {
            utils.click(utils.getElement(driver, AddNewBtn_LinkText));
            utils.elementIsDisplayed(driver, utils.getElement(driver, AddNewPagesHeaderText_Xpath));
        }

        public void enterPageTitle()
        {
            utils.sendText(utils.getElement(driver, AddPageTitleTB_ID), utils.generateRandonString());
        }

        public void clickPublishButton()
        {
            utils.click(utils.getElement(driver, AddPagePublishBtn_ID));
        }

        public void clickSaveAsDraft()
        {
            utils.click(utils.getElement(driver, SavePagesAsDraft_ID));
        }

        public void quitBrowser()
        {
            utils.quitBrowser(driver);
        }

        public bool validatePgeSavedMessage()
        {
            return utils.elementIsDisplayed(driver, utils.getElement(driver, PageDraftSavedMessage_Xpath));
        }

        public bool validatePagePublishedMessage()
        {
            return utils.elementIsDisplayed(driver, utils.getElement(driver, PagePublishedMessage_Xpath));
        }

        public void goToAllPages()
        {
            utils.click(utils.getElement(driver, AllPages_LinkText));
        }

        public void getAllPublishedCount()
        {
            IWebElement element = utils.getElement(driver, PublishedPagesCount_Xapth);
            int count = (int)element.Text[1];
            ScenarioContext.Current["PublishedPageCount"] = count;
        }

        public bool validatePublishedCountHasBeenIncreased()
        {
            IWebElement element = utils.getElement(driver, PublishedPagesCount_Xapth);
            int Newcount = (int)element.Text[1];
            int oldCount = (int)ScenarioContext.Current["PublishedPageCount"];

            if (oldCount < Newcount)
                return true;
            else
                return false;

        }

        public void getAllDraftsCount()
        {
            IWebElement element = utils.getElement(driver, SavedPagesCount_Xpath);
            int count = (int)element.Text[1];
            ScenarioContext.Current["DraftedCount"] = count;
        }

        public bool validateDraftCountHasBeenIncreased()
        {
            IWebElement element = utils.getElement(driver, SavedPagesCount_Xpath);
            int Newcount = (int)element.Text[1];
            int oldCount = (int)ScenarioContext.Current["DraftedCount"];

            if (oldCount < Newcount)
                return true;
            else
                return false;

        }

    }
}
