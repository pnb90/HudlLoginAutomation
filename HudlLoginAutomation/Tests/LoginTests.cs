﻿using HudlLoginAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HudlLoginAutomation.Tests
{
    internal class LoginTests
    {
        #region Member Variables
        IWebDriver driver;
        String email = TestContext.Parameters.Get("email");
        String password = TestContext.Parameters.Get("password");
        String baseUrl = TestContext.Parameters.Get("baseUrl");
        #endregion

        #region Constructor
        public LoginTests()
        {
            LoginPage loginPage = new LoginPage(driver);
        }
        #endregion


        #region Setup
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hudl.com/login");
        }
        #endregion


        #region Tests
        [Test]
        public void NavigateToLogin()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToPage();
            homePage.ClickLogin();

            Assert.That(driver.Url, Is.EqualTo("https://www.hudl.com/login"));
        }

        [Test]
        public void ValidEmailAndPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, password);
            loginPage.WaitForNewPageLoad(driver.Url);

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/home"));
        }

        /* No valid organization login for happy path testing 
        public void ValidOrganizationLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }
        */

        [Test]
        public void InvalidEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("invalidEmail", password);

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void InvalidPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "invalidPassword");

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        [Category("API")]
        public void NullEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("", password);

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        [Category("API")]
        public void NullPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "");

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        public void ResetPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, password);

            Assert.IsTrue(true);
        }

        #endregion


        #region Teardown
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        #endregion
    }
}
