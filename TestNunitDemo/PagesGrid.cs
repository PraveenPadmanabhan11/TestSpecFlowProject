using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
   public class PagesGrid : Page
    {
        private string AddNewBtn_LinkText = "LinkText~Add New";
        private string PublishedPagesCount_Xapth = "Xpath~//li[@class='publish']//span[@class='count']";
        private string SavedPagesCount_Xpath = "Xpath~//li[@class='draft']//span[@class='count']";
        private CreateNewPage createNewPage = new CreateNewPage();

        public void clickAddNewPage()
        {
            utils.click(utils.getElement(driver, AddNewBtn_LinkText));
            //utils.waitForPageLoad(driver, AddNewPagesHeaderText_Xpath);
            utils.elementIsDisplayed(driver, utils.getElement(driver, createNewPage.AddNewPagesHeaderText_Xpath));

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
