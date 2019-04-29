using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UkrNet.Pages;
using System.Threading;
using SeleniumExtras;


namespace UkrNet.Tests
{
    public class SentMessage
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
        public void SentMessageTest()
        {
            AuthorizationPage authorizationPage = new AuthorizationPage(driver);
            EmailPage emailPage = new EmailPage(driver);       

            var login = "lolikandbolik";
            var password = "lolik010203+";
            var loginField = authorizationPage.loginField;

            var destinationMessage = "terraco_kiev@ukr.net";
            var themeMessage = "Sending message - test";
            var bodyMessage = "Hello, Andrey! From Maryna Snitko";

            authorizationPage.loginField.SendKeys(login);
            authorizationPage.passwordField.SendKeys(password);
            authorizationPage.signinButton.Click();

            emailPage.writeMessageButton.Click();
            emailPage.destinationField.SendKeys(destinationMessage);
            emailPage.themeField.SendKeys(themeMessage);
            emailPage.attachFileButton.SendKeys("C:\\Users\\maryn\\Documents\\Test\\Test_Snitko.txt");
            //driver.FindElement(By.CssSelector("button[class='action attachments-file-button']")).SendKeys("C:\\Users\\maryn\\Documents\\Test\\test.rtf");

            driver.SwitchTo().Frame("mce_0_ifr");
            driver.FindElement(By.CssSelector("#tinymce")).SendKeys(bodyMessage);
            //emailPage.messageBodyField.SendKeys(bodyMessage);
            //emailPage.sentMessageButton.Click();
            
            driver.SwitchTo().ParentFrame();
            driver.FindElement(By.CssSelector("button[class='default send']")).Click();

            
            Thread.Sleep(5000);

            Assert.True(IsElementPresent(emailPage.messageSentMessageSucces),
                $"Element '{emailPage.messageSentMessageSucces}' is not present on the page as expected");
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
