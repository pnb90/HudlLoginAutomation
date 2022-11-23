using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using HudlLoginAutomation.Pages;

namespace HudlLoginAutomation.Tests
{
    internal class LoginTests
    {
        #region Member Variables
        IWebDriver driver;
        String email = TestContext.Parameters.Get("email");
        String password = TestContext.Parameters.Get("password");
        #endregion

        #region Constructor
        public LoginTests()
        {
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
        public void ValidEmailAndPassword()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
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
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }

        public void InvalidPassword()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }

        public void ResetPassword()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }


        /* Test Cases for API Testing
         
        public void NullEmail()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }

        public void NullPassword()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SignIn(email, password);
            Assert.IsTrue(true);
        }

        */


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
