﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public bool IsLoginValid()
        {
            bool loginValidity = false;

            try
            {

                if (IsLoginButtonEnabled() && !IsErrorDisplayed())
                {
                    loginValidity = true;
                }
                else if (!IsLoginButtonEnabled() && IsErrorDisplayed())
                {
                    loginValidity = false;
                }
                else
                {
                    throw new Exception("Login is not quite right.");
                }

            } catch (Exception ex)
            {
                //Would generally log a message to a report.

                Console.WriteLine(ex.Message);
                Console.WriteLine("IsLoginButtonEnabled " + IsLoginButtonEnabled());
                Console.WriteLine("IsErrorDisplayed " + IsErrorDisplayed());

            }

            return loginValidity;
        }


        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
        }

        #endregion

        private bool IsLoginButtonEnabled()
        {
            return loginButton.Enabled;
        }

        private bool IsErrorDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(x => GetElementCount("CssSelector", "p[data-qa-id='error-display']") > 0);

            IWebElement errorDisplay = driver.FindElement(By.CssSelector("p[data-qa-id='error-display']"));

            return errorDisplay.Displayed;
        }
    }
}
