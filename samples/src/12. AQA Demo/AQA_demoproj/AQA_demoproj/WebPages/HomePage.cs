using System;
using OpenQA.Selenium;

namespace AQA_demoproj.WebPages
{
    public class HomePage : AbstractPage
    {
        private const int DefaultWaitingInterval = 7;

        public HomePage(IWebDriver driver) : base(driver){}
        
        public IWebElement SignInButton => FindByClassName("header-auth__signin-icon", DefaultWaitingInterval);
        public IWebElement EmailInput => FindByXPath("//*[@id=\"signInEmail\"]", DefaultWaitingInterval);
        public IWebElement PasswordInput => FindByXPath("//*[@id=\"signInPassword\"]", DefaultWaitingInterval);
        public IWebElement SubmitLoginFormButton => FindByCss("input[type='submit']", DefaultWaitingInterval);
        public IWebElement LoginFormError(string textPresent) => FindByCssWithText("div.popup__error-message.ng-binding", textPresent, DefaultWaitingInterval);
        public IWebElement SelectLanguageButton => FindByClassName("location-selector__globe", DefaultWaitingInterval);
        public string BannerTitle => FindByClassName("hero-banner__heading", DefaultWaitingInterval).Text;


        public void Open()
        {
            
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Url = "http://www.training.by/?lang=en";
        }

        public void SelectLanguageFromDropDown(string language)
        {
            var xPath = $".//*[contains(@class,'location-selector__item')]//a[contains(text(),'{language}')]";
            Driver.FindElement(By.XPath(xPath)).Click();
        }
    }
}
