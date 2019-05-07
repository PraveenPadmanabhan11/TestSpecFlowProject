using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunitDemo
{
   public class CommonPage:Page
    {
        private string ProfileICon_Xpath = "Xpath~//li[@id='wp-admin-bar-my-account']//img";
        private string HomeButtonLinkText = "LinkText~opensourcecms";
        public bool ValidateProfileIconDisplayed()
        {
            return utils.elementIsDisplayed(driver,utils.getElement(driver, ProfileICon_Xpath));
        }

        public void clickHomeIcon()
        {
            utils.moveAndClick(driver, utils.getElement(driver, HomeButtonLinkText));
        }
    }
}
