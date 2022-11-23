using OpenQA.Selenium;

namespace HudlLoginAutomation.Pages
{
    internal class HomePage : BasePage
    {
        #region Web Elements
        IWebElement homeLink => driver.FindElement(By.CssSelector("a[data-qa-id='webnav-globalnav-home']"));
        IWebElement exploreLink => driver.FindElement(By.CssSelector("a[data-qa-id='webnav-globalnav-explore']"));
        IWebElement uploadLink => driver.FindElement(By.CssSelector("a[data-qa-id='webnav-globalnav-upload']"));
        IWebElement notificationsLink => driver.FindElement(By.Id("notifications-link"));
        IWebElement messagesLink => driver.FindElement(By.CssSelector("a[data-qa-id='webnav-globalnav-messages']"));

        #endregion

        #region Constructor
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #endregion
    }
}
