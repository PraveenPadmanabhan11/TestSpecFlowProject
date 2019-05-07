using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Configuration;

namespace TestNunitDemo
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private Page pageObject;
        SpecFlowFeature1Steps(Page page)
        {
            this.pageObject = page;
        }
       
        [Given(@"I am on the Login Page")]
        public void GivenIAmOnTheLoginPage()
        {
            pageObject.navigateToURL();
        }
        
        [When(@"I Enter UserName (.*) and Password (.*)")]
        public void WhenIEnterUserNameAndPassword(string userName,string password)
        {
            pageObject.enterUserName(userName);
            pageObject.enterPassword(password);
        }


        [When(@"I Enter the UserName as ""(.*)"" and Password as ""(.*)""")]
        public void WhenIEnterTheUserNameAsAndPasswordAs(string userName, string password)
        {
            pageObject.enterUserName(userName);
            pageObject.enterPassword(password);
        }

        [When(@"I Perform Login Action")]
        public void WhenIPerformLoginAction()
        {
            pageObject.clickLogin();
        }
        
        [Then(@"I should be landed on the appropriate (.*) pages")]
        public void ThenIShouldBeLandedOnTheAppropriateLandingpages(string assertionValue)
        {
           Assert.IsTrue(pageObject.AssertTheLandingPage(assertionValue));
        }

        [When(@"I Click Pages Link")]
        public void WhenIClickPagesLink()
        {
            pageObject.navigateToPages();
        }


        [When(@"I click Add New Page")]
        public void WhenIClickAddNewPage()
        {
            pageObject.clickAddNewPage();
        }

        [When(@"I enter Page Title do actions")]
        public void WhenIEnterPageTitleDoActions(Table table)
        {
            pageObject.enterPageTitle();
            foreach(var actions in table.Rows){
                foreach(var action in actions.Values)
                {
                    if (action.Equals("Publish"))
                    {
                        pageObject.clickPublishButton();
                        pageObject.validatePagePublishedMessage();
                    }
                    else
                    {
                        pageObject.clickSaveAsDraft();
                        pageObject.validatePgeSavedMessage();
                    }
                }
            }

        }

        [When(@"I get the Published Page Count")]
        public void WhenIGetThePublishedPageCount()
        {
            pageObject.getAllPublishedCount();
        }

        [Then(@"I validate the Published count has been increrased")]
        public void ThenIValidateThePublishedCountHasBeenIncrerased()
        {
            pageObject.goToAllPages();
            Assert.IsTrue(pageObject.validatePublishedCountHasBeenIncreased(),"Published Count validation Failed");
        }

        [When(@"I get the Drafted Page Count")]
        public void WhenIGetTheDraftedPageCount()
        {
            pageObject.getAllDraftsCount();
        }

        [Then(@"I validate the Drafted count has been increrased")]
        public void ThenIValidateTheDraftedCountHasBeenIncrerased()
        {
            pageObject.goToAllPages();
            Assert.IsTrue(pageObject.validateDraftCountHasBeenIncreased(), "Draft count validation failed");
        }

        [Then(@"I do Logout")]
        public void ThenIDoLogout()
        {
            pageObject.quitBrowser();
        }
    }
}
