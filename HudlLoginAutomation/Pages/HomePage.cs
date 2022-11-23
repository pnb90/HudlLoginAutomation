using OpenQA.Selenium;

namespace HudlLoginAutomation.Pages
{
    internal class HomePage : BasePage
    {
        #region Web Elements
        IWebElement loginButton => driver.FindElement(By.CssSelector("a[data-qa-id='login']"));

        #endregion

        #region Constructor
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Public Methods
        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void ClickLogin()
        {
            loginButton.Click();
        }

        #endregion

    }


}
