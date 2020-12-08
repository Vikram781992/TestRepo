using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class CheckoutPayment
    {
        IWebElement IConfirmMyOrder = DriverContext.driver.FindElement(By.XPath(".//button[@type='submit' and contains(@class,'button-medium')]"));

        public void ClickConfirmOrder() => IConfirmMyOrder.Click();
        
    }
}
