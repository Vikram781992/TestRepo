using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class SearchItemPage
    {
        IWebElement search = DriverContext.driver.FindElement(By.Id("search_query_top"));

        public void SearchInventory(string inventoryTitle)
        {
            search.ScrollTillElement();
            search.Clear();
            search.SendKeys(inventoryTitle);
        }

        IWebElement searchSubmit = DriverContext.driver.FindElement(By.Name("submit_search"));

        public SearchResult clickSearch()
        {
            searchSubmit.Click();
            return new SearchResult();
        }

        public SearchResults SearchBlouse()
        {
            searchSubmit.Click();
            return new SearchResults();
        }

        IWebElement OrderHistoryAndDetails = DriverContext.driver.FindElement(By.ClassName("icon-list-ol"));

        public OrdefrHistoryPage ClickOrderHistoryAndDetails()
        {
            OrderHistoryAndDetails.Click();
            return new OrdefrHistoryPage();
        }

    }
}
