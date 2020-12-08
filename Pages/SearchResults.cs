using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class SearchResults
    {
        IWebElement Blouse = DriverContext.driver.FindElement(By.XPath("//*[@title='Blouse']"));
        public QuickViewItemPage ClickBlouse()
        {
            Blouse.ScrollTillElement();
            Blouse.Click();
            DriverContext.driver.SwitchTo().Frame(DriverContext.driver.FindElement(By.XPath("//iframe[contains(@id,'fancybox-frame')]")));
            return new QuickViewItemPage();
        }


    }
}
