using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UkrNet.Pages;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using UkrNet.Tests;

namespace UkrNet
{
    class AuthorizationNegative : TestAbstract
    {
        [Test]
        public void AuthorizationTestNegative()
        {
            Login(validLogin, invalidPassword);

            Thread.Sleep(5000);

            AuthorizationPage authorizationPage = new AuthorizationPage(driver);
            Assert.True(IsElementPresent(authorizationPage.errorAuthorizationMessage),
                $"Element '{authorizationPage.errorAuthorizationMessage}' is not present on the page as expected");
        }
    }
}
