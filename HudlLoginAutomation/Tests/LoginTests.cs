using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
