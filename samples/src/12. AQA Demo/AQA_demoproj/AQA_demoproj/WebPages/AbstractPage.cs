using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA_demoproj.WebPages
{
    public abstract class AbstractPage
    {
        protected IWebDriver Driver;

        protected AbstractPage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement FindByCss(string css)
        {
            var locator = ExpectedConditions.ElementIsVisible(By.CssSelector(css));
            new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(locator);
            return Driver.FindElement(By.CssSelector(css));
        }

        protected IWebElement FindByCssWithText(string css, string text)
        {
            var locator = ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector(css), text);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(locator);
            return Driver.FindElement(By.CssSelector(css));
        }

        protected IWebElement FindByClassName(string className)
        {
            var locator = ExpectedConditions.ElementIsVisible(By.ClassName(className));
            new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(locator);
            return Driver.FindElement(By.ClassName(className));
        }
    }
}
