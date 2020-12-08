using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class KartPopupPage
    {
        IWebElement ContinueShopping = DriverContext.driver.FindElement(By.XPath("//span[@title='Continue shopping']").WaitForElement());

        public SearchResult ClickContinueShopping()
        {
            ContinueShopping.Click();

            return new SearchResult();
        }

        IWebElement ProceeedToCheckout = DriverContext.driver.FindElement(By.XPath("//a[@title='Proceed to checkout']").WaitForElement());

        public ViewItemsPage ClickViewItemPage()
        {
            ProceeedToCheckout.Click();
            return new ViewItemsPage();
        }

    }
}
