using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class OrdefrHistoryPage
    {
        IWebElement OrderId = DriverContext.driver.FindElement(By.XPath("//*[contains(text(),'ZRDUWYCNV') and contains(@class,'myaccount')]"));

        public OrderHistoryDetailsPage ClickOnOrderReference()
        {
            OrderId.Click();
            return new OrderHistoryDetailsPage();
        }

        IWebElement GetDateTime = DriverContext.driver.FindElement(By.XPath(".//td[@data-value='20201207045709']"));


        public void ValidateDateTime()
        {
            Assert.That(GetDateTime.Text, Is.EqualTo("12/07/2020"));
            
        }
    }
}
