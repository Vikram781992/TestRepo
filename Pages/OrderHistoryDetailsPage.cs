using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class OrderHistoryDetailsPage
    {
        IWebElement SelectProduct = DriverContext.driver.FindElement(By.XPath(".//select[@name='id_product']"));
        
        public void SelectItem(int index)
        {
            SelectElement sel = new SelectElement(SelectProduct);
            sel.SelectByIndex(index);
        }


        IWebElement TextField = DriverContext.driver.FindElement(By.XPath(".//textarea[@class='form-control']"));
        
        public void AddComment(string Comments)
        {
            TextField.SendKeys(Comments);
        }

        IWebElement SubmitMessage = DriverContext.driver.FindElement(By.XPath("//button[@name='submitMessage']"));

        public MessageSent ClickSubmitMessage()
        {
            SubmitMessage.Click();
            return new MessageSent();
        }
        
    }
}
