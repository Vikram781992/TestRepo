using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class LoginPage
    {
        IWebElement userName = DriverContext.driver.FindElement(By.Id("email"));

        public void AddUserName(string Name)
        {
            userName.MoveToElement();
            userName.SendKeys(Name);
        }

        IWebElement password = DriverContext.driver.FindElement(By.Id("passwd"));

        public void AddPassword(string pass) => password.SendKeys(pass);

        IWebElement BtnSubmit = DriverContext.driver.FindElement(By.Id("SubmitLogin"));

        public SearchItemPage ClickSubmit()
        {
            BtnSubmit.Click();
            return new SearchItemPage();
        }
    }
}
