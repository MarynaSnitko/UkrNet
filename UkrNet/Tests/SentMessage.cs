using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UkrNet.Pages;
using System.Threading;
using SeleniumExtras;


namespace UkrNet.Tests
{
    public class SentMessage : TestAbstract
    {
        
        [Test]
        public void SentMessageTest()
        {
            Login(validLogin, validPassword);

            EmailPage emailPage = new EmailPage(driver);

            var destinationMessage = "terraco_kiev@ukr.net";
            var themeMessage = "Sending message - test";
            var bodyMessage = "Hello, Andrey! From Maryna Snitko";

            emailPage.writeMessageButton.Click();
            emailPage.destinationField.SendKeys(destinationMessage);
            emailPage.themeField.SendKeys(themeMessage);
            emailPage.attachFileButton.SendKeys("C:\\Users\\maryn\\Documents\\Test\\Test_Snitko.txt");

            driver.SwitchTo().Frame("mce_0_ifr");
            driver.FindElement(By.CssSelector("#tinymce")).SendKeys(bodyMessage);
            
            driver.SwitchTo().ParentFrame();
            driver.FindElement(By.CssSelector("button[class='default send']")).Click();
            
            Thread.Sleep(5000);

            Assert.True(IsElementPresent(emailPage.messageSentMessageSucces),
                $"Element '{emailPage.messageSentMessageSucces}' is not present on the page as expected");
        }
    }
}
