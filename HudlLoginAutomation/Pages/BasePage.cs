using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudlLoginAutomation.Pages
{
    public class BasePage
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
        }

        public void EnterText(WebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
