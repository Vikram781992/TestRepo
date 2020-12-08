using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class CheckoutShipping
    {

        IWebElement ProceedToCheckout = DriverContext.driver.FindElement(By.XPath("//button[@type='submit' and @name='processCarrier']"));

        public PaymentsPage ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            return new PaymentsPage();
        }

        IWebElement TermsAndConditionCheckbox = DriverContext.driver.FindElement(By.Id("cgv"));

        public void ClickTermsAndConditionsCheckbox() => TermsAndConditionCheckbox.Click();
        

    }
}
