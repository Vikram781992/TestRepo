using OpenQA.Selenium;
using System;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class ViewItemsPage
    {
        
        IWebElement ProceedToCheckout = DriverContext.driver.FindElement(By.XPath("//*[contains(@class,'cart_navigation clearfix')]//a[@title='Proceed to checkout']"));

        public CheckoutAddressPage ClickProceedToCheckout()
        {
           
            ProceedToCheckout.Click();
            return new CheckoutAddressPage();
        }

        public void VarifyPriceSizeKartTotal()
        {
            VaerifySize();
            VaerifyPrice();
            VerifyCartTotal();
        }

        public void VaerifyPrice()
        {
            
            var Price = DriverContext.driver.FindElements(By.XPath("//*[@class='cart_total']//span"));

            for (int i = 0; i < Price.Count; i++)
            {
                Convert.ToDecimal(Price[i].Text.Replace('$', ' ').Trim().ToString().Equals(SaveItem.Price[i].ToString()));
            }
        }

        
        public bool VerifyCartTotal()
        {
            var Price = DriverContext.driver.FindElements(By.XPath("//*[@class='cart_total']//span"));
            decimal ShippingPrice = Convert.ToDecimal(DriverContext.driver.FindElement(By.Id("total_shipping")).Text.Replace('$', ' ').Trim());
            
            decimal savedFinalPrice = 0;
            for (int i = 0; i < Price.Count; i++)
            {
                savedFinalPrice += Convert.ToDecimal(Price[i].Text.Replace('$', ' ').Trim());
            }

            decimal finalPrice = 0;
            for(int i=0;i< SaveItem.Price.Count;i++)
            {
                 finalPrice += SaveItem.Price[i];
            }

            return savedFinalPrice + ShippingPrice == finalPrice + ShippingPrice ? true : false;
        }

        
        public void VaerifySize()
        {
            var Sizes = DriverContext.driver.FindElements(By.XPath("//*[contains(@class,'cart_description')]//small[2]"));

            for (int i=0;i< Sizes.Count;i++)
            {
                Sizes[i].Text.Contains(SaveItem.Size[i]);
            }
        
        }
    }
}
