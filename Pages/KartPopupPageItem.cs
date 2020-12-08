using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class KartPopupPageItem
    {
        IWebElement ProceeedToCheckout = DriverContext.driver.FindElement(By.XPath("//a[@title='Proceed to checkout']").WaitForElement());

        public ViewItemsPage ClickViewItemPage()
        {
            ProceeedToCheckout.Click();
            return new ViewItemsPage();
        }

    }
}
