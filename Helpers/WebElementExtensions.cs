using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject.Helpers
{
    public static class WebElementExtensions
    {
        public static void MoveToElement(this IWebElement element)
        {
            Actions act = new Actions(DriverContext.driver);
            act.MoveToElement(element)
               .Build()
               .Perform();

        }

        public static void ScrollTillElement(this IWebElement element)
        {
            ((IJavaScriptExecutor)DriverContext.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static By WaitForElement(this By element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(element));
            return element;
        }
    }
}