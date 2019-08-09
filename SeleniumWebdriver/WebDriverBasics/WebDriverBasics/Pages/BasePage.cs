using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WebDriverBasics
{
    abstract class BasePage
    {
        public IWebDriver Driver { get; }
        public IJavaScriptExecutor js;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            js = Driver as IJavaScriptExecutor;
        }

        public bool IsElementPresented(string XPath)
        {
            return Driver.FindElements(By.XPath(XPath)).Count > 0;
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
    }
}
