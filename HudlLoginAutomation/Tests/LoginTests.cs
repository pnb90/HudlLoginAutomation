using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace HudlLoginAutomation.Tests
{
    internal class LoginTests
    {
        IWebDriver driver;

        public LoginTests()
        {
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void FirstTest()
        {
            driver.Navigate().GoToUrl("https://hudl.com/login");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
