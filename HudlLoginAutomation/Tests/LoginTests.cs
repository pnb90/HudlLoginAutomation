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
        public void FailedLoginTestInvalidEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("invalidEmail", password);

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void FailedLoginTestInvalidPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "invalidPassword");

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void NavigateToLoginTest()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToPage();
            homePage.ClickLogin();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
        }

        [Test]
        public void NavigateToOrganizationLoginTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickOrganizationLogInButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/app/auth/login/organization"));
        }

        [Test]
        public void NavigateToPasswordResetTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickNeedHelpButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login/help#"));
        }

        [Test]
        public void NavigateToPasswordResetInvalidEmailTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("invalidEmail", password);

            Assert.False(loginPage.IsLoginValid());

            loginPage.ClickNeedHelpInvalidEmailButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login/help"));
            Assert.That(loginPage.GetEmailText(), Is.EqualTo("invalidEmail"));
        }

        [Test]
        public void NavigateToSignUpTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickSignUpButton();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register/signup"));
        }

        [Test]
        public void FailedLoginTestNullEmail()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn("", password);

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void FailedLoginTestNullPassword()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.SignIn(email, "");

            Assert.IsFalse(loginPage.IsLoginValid());
        }

        [Test]
        public void SuccessfulLoginValidEmailAndPassword()
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
