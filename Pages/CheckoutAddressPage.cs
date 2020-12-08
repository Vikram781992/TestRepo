using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class CheckoutAddressPage
    {
        IWebElement ProceedToCheckout = DriverContext.driver.FindElement(By.XPath("//button[@type='submit' and @name='processAddress']"));

        public CheckoutShipping ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            return new CheckoutShipping();
        }


    }
}
