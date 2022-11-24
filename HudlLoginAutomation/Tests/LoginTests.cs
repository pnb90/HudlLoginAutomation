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
            driver.Navigate().GoToUrl(baseUrl + "/login");
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

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
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
