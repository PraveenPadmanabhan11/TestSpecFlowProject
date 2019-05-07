using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace TestNunitDemo
{
    public class Utils
    {

        
        private IWebDriver driver;
       static string waitDuration = ConfigurationManager.AppSettings["WaitDuration"];
        int waitTime = Int32.Parse(waitDuration);
        public void navigateTo(IWebDriver driver,string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string getText(IWebDriver driver, IWebElement element)
        {
            return element.Text;
        }

        public void quitBrowser(IWebDriver driver)
        {
            driver.Quit();
        }

        public bool elementIsDisplayed(IWebDriver driver, IWebElement element)
        {
            return element.Displayed;
        }

        public bool elementIsEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public void waitUntilElementDisplayed(By element, IWebDriver driver)
        {
            var driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public void navigateToURL(string url, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool validateText(IWebElement element,string expectedText)
        {
            string actualText = this.getText(null, element);
            if (actualText.Equals(expectedText))
                return true;
            else
                return false;
        }

        public IReadOnlyCollection<IWebElement> getElements(IWebDriver driver,string findByText)
        {
            var driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            String[] identifierType = findByText.Split('~');
            IReadOnlyCollection<IWebElement> elements;
            string identifier = identifierType[1];
            switch (identifierType[0])
            {
                case "Xpath":
                    elements = driverWait.Until(x => x.FindElements((By.XPath(identifier)))); 
                break;
                case "Id":
                    elements = driverWait.Until(x => x.FindElements((By.Id(identifier))));
                    break;
                case "Name":
                    elements = driverWait.Until(x => x.FindElements((By.Name(identifier))));
                    break;
                case "CSS":
                    elements = driverWait.Until(x => x.FindElements((By.CssSelector(identifier))));
                    break;
                case "LinkText":
                    elements = driverWait.Until(x => x.FindElements((By.LinkText(identifier))));
                    break;
                case "ClassName":
                    elements = driverWait.Until(x => x.FindElements((By.ClassName(identifier))));
                    break;
                case "TagName":
                    elements = driverWait.Until(x => x.FindElements((By.TagName(identifier))));
                    break;
                case "PartialLinkText":
                    elements = driverWait.Until(x => x.FindElements((By.PartialLinkText(identifier))));
                    break;
                default:
                    elements = null;
                break;
            }
            return elements;

        }

        public IWebElement getElement(IWebDriver driver,string findByText)
        {
            String[] identifierType = findByText.Split('~');
            IWebElement element;
            string identifier = identifierType[1];
            var driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            switch (identifierType[0])
            {
                case "Xpath":
                    
                    driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(identifier)));
                    element =  driver.FindElement((By.XPath(identifier)));
                    break;
                case "Id":
                    element = driverWait.Until(x => x.FindElement((By.Id(identifier))));
                    break;
                case "Name":
                    element = driverWait.Until(x => x.FindElement((By.Name(identifier))));
                    break;
                case "CSS":
                    element = driverWait.Until(x => x.FindElement((By.CssSelector(identifier))));
                    break;
                case "LinkText":
                    element = driverWait.Until(x => x.FindElement((By.LinkText(identifier))));
                    break;
                case "ClassName":
                    element = driverWait.Until(x => x.FindElement((By.ClassName(identifier))));
                    break;
                case "TagName":
                    element = driverWait.Until(x => x.FindElement((By.TagName(identifier))));
                    break;
                case "PartialLinkText":
                    element = driverWait.Until(x => x.FindElement((By.PartialLinkText(identifier))));
                    break;
                default:
                    element = null;
                    break;
            }
            return element;

        }

        public void click(IWebElement element)
        {
            element.Click();

        }

        public void moveAndClick(IWebDriver driver,IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Click();

        }

        public void waitForPageLoad(IWebDriver driver,string identifier)
        {
            var driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            string[] value = identifier.Split('~');
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(value[1])));
        }

        public void sendText(IWebElement element,string value)
        {
            element.SendKeys(value);
        }

        
        public  IWebDriver instantiateDriver(string DriverOptions)
        {
            
            switch (DriverOptions)
            {
                case "FireFox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\ppadmanabhan\Documents\Visual Studio 2019", "geckodriver.exe");
                    driver = new FirefoxDriver(service);
                    driver.Manage().Window.Maximize();

                    break;
                case "Chrome":
                    driver = new ChromeDriver(@"C:\Users\ppadmanabhan\Downloads\chromedriver_win32");
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    
                    break;
                default:
                    driver = null;
                    break;
            }
            return driver;
        }

        public string generateRandonString()
        {
         Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }


    }
}
