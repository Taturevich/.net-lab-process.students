using System.Threading.Tasks;
using AQA_demoproj.WebPages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AQA_demoproj.Steps
{
    [Binding]
    public class LocalisationSteps
    {
        private static HomePage HomePage => PageFactory.Get<HomePage>();

        [When(@"User sets site language to ""(.*)""")]
        public async Task WhenUserSetsSiteLanguageTo(string language)
        {
            HomePage.SelectLanguageButton.Click();
            await Task.Delay(300);
            HomePage.SelectLanguageFromDropDown(language);
        }

        [Then(@"Banner text is ""(.*)""")]
        public void ThenBannerTextIs(string bannerText)
        {
            var actualText = HomePage.BannerTitle.Replace("\r\n", " ");
            Assert.That(actualText.Contains(bannerText));
        }
    }
}
