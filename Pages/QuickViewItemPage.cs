using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class QuickViewItemPage
    {
        
        IWebElement SelectSize = DriverContext.driver.FindElement(By.Id("group_1"));
        string price = DriverContext.driver.FindElement(By.Id("our_price_display")).Text.Replace('$',' ').Trim();

        public void SelectFromDropdown(string Text)
        {
            SelectElement sel = new SelectElement(SelectSize);
            sel.SelectByText(Text);
        }

        IWebElement AddToCart = DriverContext.driver.FindElement(By.Id("add_to_cart"));

         


        public KartPopupPage AddItemToCart()
        {

            string Size = DriverContext.driver.FindElement(By.XPath("//*[@id = 'group_1']//option[@selected='selected']")).Text;

            SaveItem.Size.Add(Size);
            SaveItem.Price.Add(Convert.ToDecimal(price));
            AddToCart.Click();

            
            return new KartPopupPage();
        }

        public KartPopupPageItem AddItemIntoCart()
        {

            string Size = DriverContext.driver.FindElement(By.XPath("//*[@id = 'group_1']//option[@selected='selected']")).Text;

            SaveItem.Size.Add(Size);
            SaveItem.Price.Add(Convert.ToDecimal(price));
            AddToCart.Click();
            return new KartPopupPageItem();
        }

    }
}
