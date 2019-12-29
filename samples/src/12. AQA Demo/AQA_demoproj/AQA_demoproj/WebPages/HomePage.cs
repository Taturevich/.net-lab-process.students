using System;
using OpenQA.Selenium;

namespace AQA_demoproj.WebPages
{
    public class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver) : base(driver){}
        
        public IWebElement SignInButton => FindByClassName("header-auth__signin-icon");
        public IWebElement EmailInput => FindByCss("input[id='signInEmail']");
        public IWebElement PasswordInput => FindByCss("input[id='signInPassword']");
        public IWebElement SubmitLoginFormButton => FindByCss("input[type='submit']");
        public IWebElement LoginFormError(string textPresent) => FindByCssWithText("div.popup__error-message.ng-binding", textPresent);
        public IWebElement SelectLanguageButton => FindByClassName("location-selector__globe");
        public string BannerTitle => FindByClassName("hero-banner__heading").Text;


        public void Open()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Url = "http://www.training.by";
        }

        public void SelectLanguageFromDropDown(string language)
        {
            var xPath = $".//*[contains(@class,'location-selector__item')]//a[contains(text(),'{language}')]";
            Driver.FindElement(By.XPath(xPath)).Click();
        }
    }
}
