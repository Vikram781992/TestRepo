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
    class MessageSent
    {

        IWebElement MessageSentText = DriverContext.driver.FindElement(By.XPath("//p[contains(@class,'alert')]"));

        public void VerifyMessageSentMessage() => MessageSentText.Text.Trim().Equals("Message successfully sent");
        
        IWebElement VerifyComment = DriverContext.driver.FindElement(By.XPath("//*[@id='block-order-detail']/div[5]/table/tbody/tr/td[2]"));

        public void VerfyCommentText(string CommentText)
        {
           Assert.IsTrue(VerifyComment.Text.Equals(CommentText));
        }

        IWebElement Logout = DriverContext.driver.FindElement(By.XPath(".//a[@class='logout']"));

        public void ClickLogout()
        {
            Logout.Click();
        }

    }
}
