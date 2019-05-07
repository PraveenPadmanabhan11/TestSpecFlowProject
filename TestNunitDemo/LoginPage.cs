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
   public class LoginPage : Page
    {
        private string UserNameTB_Xpath = "Xpath~//input[@id='user_login']";
        private string PasswordTB_Xpath = "Xpath~//input[@id='user_pass']";
        private string LoginBtn_Xpath = "Xpath~//input[@id='wp-submit']";
        private string LoginError_Id = "Id~login_error";

        public void enterUserName(string userName)
        {
            ScenarioContext.Current["userNameValue"] = userName;
            utils.sendText(utils.getElement(driver, UserNameTB_Xpath), userName);
            //IWebElement userNameTB = driver.FindElement(By.XPath(UserNameTB_Xpath));
            //userNameTB.SendKeys(userName);
        }

        public void enterPassword(string password)
        {
            utils.sendText(utils.getElement(driver, PasswordTB_Xpath), password);
            //IWebElement passwordTB = driver.FindElement(By.XPath(PasswordTB_Xpath));
            //passwordTB.SendKeys(password);
        }

        public void clickLogin()
        {
            utils.click(utils.getElement(driver, LoginBtn_Xpath));
            //IWebElement loginBtn = driver.FindElement(By.XPath(LoginBtn_Xpath));
            //loginBtn.Click();
        }

        public bool AssertTheLandingPage(string assertionCondition)
        {
            string name = (string)ScenarioContext.Current["userNameValue"];
            if (assertionCondition.Equals("True"))
                return utils.elementIsDisplayed(driver, utils.getElement(driver, "Xpath~//li[@id='wp-admin-bar-my-account']//span[contains(.,'" + name + "')]"));
            else
                return utils.elementIsDisplayed(driver, utils.getElement(driver, LoginError_Id));
        }


    }
}
