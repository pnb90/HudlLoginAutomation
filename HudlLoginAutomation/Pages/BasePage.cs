using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HudlLoginAutomation.Pages
{
    public class BasePage
    {
        #region Member Variables
        public IWebDriver driver { get; set; }
        public String baseUrl = TestContext.Parameters.Get("baseUrl");

        #endregion

        #region Constructors

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Public Methods
        public void EnterText(IWebElement element, String text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not enter text: " + ex.Message);
            }
        }

        public int GetElementCount(String locatorStrategy, String locatorText)
        {
            int elementCount = 0;

            switch (locatorStrategy)
            {
                case "CssSelector":
                    elementCount = driver.FindElements(By.CssSelector($"{locatorText}")).Count;
                    break;
                case "Id":
                    elementCount = driver.FindElements(By.Id($"{locatorText}")).Count;
                    break;
            }

            return elementCount;
        }

        public void WaitForNewPageLoad(String initialUrl)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(x => initialUrl != GetCurrentUrl());
        }

        #endregion

        #region Private Methods

        private string GetCurrentUrl()
        {
            return driver.Url;
        }
        #endregion
    }
}
