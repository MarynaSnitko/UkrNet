using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UkrNet.Pages;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace UkrNet
{
    class AuthorizationNegative
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://accounts.ukr.net/login?lang=ru");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void AuthorizationTestNegative()
        {
            AuthorizationPage authorizationPage = new AuthorizationPage(driver);

            var login = "lolikandbolik";
            var password = "111";
            var loginField = authorizationPage.loginField;
            authorizationPage.loginField.SendKeys(login);
            authorizationPage.passwordField.SendKeys(password);
            authorizationPage.signinButton.Click();

            Thread.Sleep(5000);

            Assert.True(IsElementPresent(authorizationPage.errorAuthorizationMessage),
                $"Element '{authorizationPage.errorAuthorizationMessage}' is not present on the page as expected");
        }

        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                var result = element.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            throw new Exception("Unexpected exception.");
        }
    }
}
