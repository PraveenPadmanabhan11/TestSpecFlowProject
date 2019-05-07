using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunitDemo
{
    public class VerticalMenuPage : Page
    {
        private string PagesLink_Xpath = "Xpath~//div[contains(.,'Pages')]";
        private string AllPages_LinkText = "LinkText~All Pages";
        private string PagesHeaderText_Xpath = "Xpath~//h1[@class='wp-heading-inline']";

        public bool navigateToPages()
        {
            utils.click(utils.getElement(driver, PagesLink_Xpath));
            //utils.waitForPageLoad(driver, PagesHeaderText_Xpath);

            string pageHeader = utils.getText(driver, utils.getElement(driver, PagesHeaderText_Xpath));
            //IWebElement pagesLink = driver.FindElement(By.XPath(PagesLink_Xpath));
            //pagesLink.Click();
            //string pageHeader = driver.FindElement(By.XPath(PagesHeaderText)).Text;
            if (pageHeader.Equals("Pages"))
                return true;
            else
                return false;
        }

        public void goToAllPages()
        {
            utils.click(utils.getElement(driver, AllPages_LinkText));
            //utils.waitForPageLoad(driver, PagesHeaderText_Xpath);
        }

    }
}
