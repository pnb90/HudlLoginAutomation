using OpenQA.Selenium;

namespace HudlLoginAutomation.Pages
{
    internal class LoginPage : BasePage
    {
        #region Web Elements
        IWebElement emailInput => driver.FindElement(By.Id("email"));
        IWebElement passwordInput => driver.FindElement(By.Id("password"));
        IWebElement loginButton => driver.FindElement(By.Id("logIn"));
        IWebElement rememberMeCheckbox => driver.FindElement(By.Id("uniId_2"));
        IWebElement needHelpLink => driver.FindElement(By.CssSelector("a[data-qa-id='need-help-link']"));
        IWebElement signUpLink => driver.FindElement(By.CssSelector("a[href='/register/signup']"));
        IWebElement organizationLogInButton => driver.FindElement(By.CssSelector("button[data-qa-id='log-in-with-organization-btn']"));
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Public Methods 
        public void SignIn(String email, String password)
        {
            EnterText(emailInput, email);
            EnterText(passwordInput, password);
            loginButton.Click();
        }
        #endregion

    }
}
