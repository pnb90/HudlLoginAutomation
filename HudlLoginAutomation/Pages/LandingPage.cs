using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudlLoginAutomation.Pages
{
    internal class LandingPage : BasePage
    {
        #region Web Elements
        IWebElement loginButton => driver.FindElement(By.CssSelector("a[data-qa-id='login']"));
 
        #endregion

        #region Constructor
        public LandingPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Public Methods
        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
            //WaitForPageLoad();
        }

        public void ClickLogin()
        {
            loginButton.Click();
            //WaitForPageLoad();
        }

        #endregion

    }


}
