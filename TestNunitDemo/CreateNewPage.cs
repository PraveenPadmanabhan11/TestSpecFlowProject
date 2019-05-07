using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunitDemo
{
    public class CreateNewPage: Page
    {
        private string AddPageTitleTB_ID = "Id~title";
        private string AddPageSaveDraftBtn_ID = "Id~save-post";
        private string AddPagePublishBtn_ID = "Id~publish";
        private string PagePublishedMessage_Xpath = "Xpath~//div[@id='message']//p[contains(.,'Page published')]";
        private string PageDraftSavedMessage_Xpath = "Xpath~//div[@id='message']//p[contains(.,'Page draft updated')]";
        private string SavePagesAsDraft_ID = "Id~save-post";
        public string AddNewPagesHeaderText_Xpath = "Xpath~//h1[contains(.,'Add New Page')]";

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

        public bool validatePgeSavedMessage()
        {
            return utils.elementIsDisplayed(driver, utils.getElement(driver, PageDraftSavedMessage_Xpath));
        }

        public bool validatePagePublishedMessage()
        {
            return utils.elementIsDisplayed(driver, utils.getElement(driver, PagePublishedMessage_Xpath));
        }

    }
}
