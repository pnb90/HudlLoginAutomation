using HudlLoginAutomation.Pages;
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
        public void NavigateToLogin()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToPage();
            homePage.ClickLogin();

            Assert.That(driver.Url, Is.EqualTo("https://www.hudl.com/login"));
        }

        [Test]
        public void NavigateToOrganizationLogin()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickOrganizationLogInButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/app/auth/login/organization"));
        }

        [Test]
        public void NavigateToPasswordReset()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickNeedHelpButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login/help#"));
        }

        [Test]
        public void NavigateToPasswordResetInvalidEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("invalidEmail", password);

            Assert.False(loginPage.IsLoginValid());

            loginPage.ClickNeedHelpInvalidEmailButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login/help"));
            Assert.That(loginPage.GetEmailText(), Is.EqualTo("invalidEmail"));
        }

        [Test]
        public void NavigateToSignUp()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickSignUpButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register/signup"));
        }

        [Test]
        public void NullEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("", password);

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void NullPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "");

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void ValidEmailAndPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, password);
            loginPage.WaitForNewPageLoad(driver.Url);

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/home"));
        }

        /* Reset Email Tests 
        [Test]
        public void UserAbleToResetPasswordWithValidEmail()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickNeedHelpButton();
            loginPage.ResetPassword("anything@test.com");

            Assert.isTrue(loginPage.IsConfirmationTextPresent());
            
            // better yet is checking the API has been hit to send out a password reset email.
        }

        [Test]
        public void UserNotAbleToResetPasswordWithInvalidEmail()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickNeedHelpButton();
            loginPage.ResetPassword("invalid");

            Assert.isTrue(loginPage.IsPasswordResetErrorDisplayPresent());
        }
        */

        /* Would need tests for organizational login but no valid test data at the moment

        public void ValidOrganizationLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.OrganizationalSignIn(email);
            Assert.IsTrue(true);
        }

        */

        /* Tests around Remember Me functionality via cookie creation 
         
        public void RememberMeCookieSaved()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "");
            Cookie rememberMeCookie = driver.Manage().Cookies.GetCookieNamed("remember_token");
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
