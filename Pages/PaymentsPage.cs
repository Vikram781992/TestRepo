using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class PaymentsPage
    {

        IWebElement PayByBankWire = DriverContext.driver.FindElement(By.XPath("//a[@class='bankwire']"));

        public CheckoutPayment ClickProceedToCheckout()
        {
            PayByBankWire.Click();
            return new CheckoutPayment();
        }

       
    }
}
