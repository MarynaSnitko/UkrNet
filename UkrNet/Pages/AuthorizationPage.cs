using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrNet.Pages
{
    public class AuthorizationPage
    {
        public IWebDriver driver;
        public AuthorizationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[type='text']")]
        public IWebElement loginField;

        [FindsBy(How = How.CssSelector, Using = "[type='password']")]
        public IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = "[class='button button_style-main button_size-regular form__submit']")]
        public IWebElement signinButton;

        [FindsBy(How = How.CssSelector, Using = "[class='form__error form__error_fail']")]
        public IWebElement errorAuthorizationMessage;
    }
}
