using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    class MainPage
    {

        IWebElement signInButton => DriverContext.driver.FindElement(By.XPath(".//*[@class='header_user_info']"));

        public LoginPage ClickSignIn()
        {
            signInButton.Click();
            return new LoginPage();
        }

    }
}
