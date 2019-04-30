using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UkrNet.Pages;
using System.Threading;
using SeleniumExtras;

namespace UkrNet.Tests
{
    public class TestAbstract
    {
        public IWebDriver driver;

        public string validLogin = "lolikandbolik";
        public string validPassword = "lolik010203+";
        public string invalidPassword = "111";

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

        public void Login(string login, string password)
        {
            AuthorizationPage authorizationPage = new AuthorizationPage(driver);
            authorizationPage.loginField.SendKeys(login);
            authorizationPage.passwordField.SendKeys(password);
            authorizationPage.signinButton.Click();
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
