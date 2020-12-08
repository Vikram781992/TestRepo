using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class SearchResult
    {
        IWebElement ShortSleev = DriverContext.driver.FindElement(By.XPath("//*[@title='Faded Short Sleeve T-shirts']").WaitForElement());  

        public QuickViewItemPage ClickSearchResult()
        {
            ShortSleev.ScrollTillElement();
            ShortSleev.Click();
            DriverContext.driver.SwitchTo().Frame(DriverContext.driver.FindElement(By.XPath("//iframe[contains(@id,'fancybox-frame')]").WaitForElement()));
            return new QuickViewItemPage();
        }

        IWebElement search = DriverContext.driver.FindElement(By.Id("search_query_top"));

        public void SearchInventory(string inventoryTitle)
        {
            search.ScrollTillElement();
            search.Clear();
            search.SendKeys(inventoryTitle);
        }

        IWebElement searchSubmit = DriverContext.driver.FindElement(By.Name("submit_search"));

        public SearchResults SearchBlouse()
        {
            searchSubmit.Click();
            return new SearchResults();
        }

    }
}
