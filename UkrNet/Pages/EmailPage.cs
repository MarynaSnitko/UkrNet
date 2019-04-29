using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrNet.Pages
{
    public class EmailPage
    {
        public IWebDriver driver;
        public EmailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='default compose']")]
        public IWebElement writeMessageButton;

        [FindsBy(How = How.CssSelector, Using = "[name='toFieldInput']")]
        public IWebElement destinationField;

        [FindsBy(How = How.CssSelector, Using = "[name='subject']")]
        public IWebElement themeField;

        [FindsBy(How = How.XPath, Using = "#tinymce")]
        public IWebElement messageBodyField;

        [FindsBy(How = How.CssSelector, Using = "button[class='default send']")]
        public IWebElement sentMessageButton;

        [FindsBy(How = How.CssSelector, Using = "iframe[id='mce_1_ifr']")]
        public IWebElement messageBodyFrame;

        [FindsBy(How = How.CssSelector, Using = "#file-to-upload")]
        public IWebElement attachFileButton;

        [FindsBy(How = How.CssSelector, Using = "[class='sendmsg__ads-ready']")]
        public IWebElement messageSentMessageSucces;
    }
}
