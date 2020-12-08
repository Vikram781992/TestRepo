using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using TestProject.Helpers;
using TestProject.Pages;

namespace TestProject.Tests
{
    [TestFixture]
    class EndtoEndTests
    {
        private ConfigReader configReader;
        private MainPage mainPage;
        private LoginPage loginPage;
        private SearchItemPage searchItemPage;
        private SearchResult searchResult;
        private QuickViewItemPage quickViewItemPage;
        private ViewItemsPage viewItemsPage;
        private KartPopupPage kartPopupPage;
        private SearchResults searchResults;
        private KartPopupPageItem kartPopupPageItem;
        private CheckoutAddressPage checkoutAddressPage;
        private CheckoutShipping checkoutShipping;
        private PaymentsPage paymentsPage;
        private CheckoutPayment checkoutPayment;
        private OrdefrHistoryPage ordefrHistoryPage;
        private OrderHistoryDetailsPage orderHistoryDetailsPage;
        private MessageSent messageSent;
       

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Environment.SetEnvironmentVariable("webdriver.chrome.driver",
              @"C: \Users\vikram.mahurkar\source\repos\TestProject\chromedriver.exe");
        }

        [SetUp]
        public void Setup()
        {
            DriverContext.driver = new ChromeDriver();
            DriverContext.driver.Manage().Window.Maximize();
            DriverContext.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            configReader = new ConfigReader();
            DriverContext.driver.Url = configReader.BaseURL;
            mainPage = new MainPage();
            LoginToApplication();
        }

        [Test]
        public void HappyPathPurchaseTwoItems()
        {
            searchItemPage.SearchInventory("Faded Short Sleeve T-shirts");
            searchResult = searchItemPage.clickSearch();
            quickViewItemPage = searchResult.ClickSearchResult();
            quickViewItemPage.SelectFromDropdown("M");
            kartPopupPage = quickViewItemPage.AddItemToCart();
            searchResult = kartPopupPage.ClickContinueShopping();
            searchResult.SearchInventory("Blouse");
            searchResults = searchResult.SearchBlouse();
            quickViewItemPage = searchResults.ClickBlouse();
            kartPopupPageItem = quickViewItemPage.AddItemIntoCart();
            viewItemsPage = kartPopupPageItem.ClickViewItemPage();
            viewItemsPage.VarifyPriceSizeKartTotal();
            checkoutAddressPage =  viewItemsPage.ClickProceedToCheckout();
            checkoutShipping = checkoutAddressPage.ClickProceedToCheckout();
            checkoutShipping.ClickTermsAndConditionsCheckbox();
            paymentsPage = checkoutShipping.ClickProceedToCheckout();
            checkoutPayment = paymentsPage.ClickProceedToCheckout();
            checkoutPayment.ClickConfirmOrder();
        }

        [Test]
        public void verifyItemPurchased()
        {
            ordefrHistoryPage = searchItemPage.ClickOrderHistoryAndDetails();
            ordefrHistoryPage.ValidateDateTime();
            orderHistoryDetailsPage =  ordefrHistoryPage.ClickOnOrderReference();
            orderHistoryDetailsPage.SelectItem(1);
            orderHistoryDetailsPage.AddComment("Test Comments");
            messageSent = orderHistoryDetailsPage.ClickSubmitMessage();
            messageSent.VerifyMessageSentMessage();
            messageSent.VerfyCommentText("Test Comments");
            messageSent.ClickLogout();
        }

        [Test]
        public void CaptureFailureScreenshot()
        {
            try
            {
                ordefrHistoryPage = searchItemPage.ClickOrderHistoryAndDetails();
                ordefrHistoryPage.ValidateDateTime();
                orderHistoryDetailsPage = ordefrHistoryPage.ClickOnOrderReference();
                orderHistoryDetailsPage.SelectItem(1);
                orderHistoryDetailsPage.AddComment("Test Comments");
                messageSent = orderHistoryDetailsPage.ClickSubmitMessage();
                messageSent.VerifyMessageSentMessage();
                messageSent.VerfyCommentText("Test");
                messageSent.ClickLogout();
            }
            catch(Exception ex)
            {
                string date = DateTime.Now.ToString("HHmmss");
                ((ITakesScreenshot)DriverContext.driver).GetScreenshot().SaveAsFile(@"C:\Users\vikram.mahurkar\source\repos\TestProject\Screenshot\"+date+"Img.png");
            }
        }

        

        private void LoginToApplication()
        {
            loginPage = mainPage.ClickSignIn();
            loginPage.AddUserName(configReader.UserName);
            loginPage.AddPassword(configReader.Password);
            searchItemPage = loginPage.ClickSubmit();
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            DriverContext.driver.Quit();
        }

    }
}
