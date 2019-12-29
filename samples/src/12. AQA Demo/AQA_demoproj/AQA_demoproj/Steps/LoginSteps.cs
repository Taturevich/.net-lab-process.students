using AQA_demoproj.WebPages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AQA_demoproj.Steps
{
    [Binding]
    public class LoginSteps
    {
        private static HomePage HomePage => PageFactory.Get<HomePage>();
        
        [Given(@"User is on training\.by")]
        public void GivenUserIsOnTraining_By()
        {
            HomePage.Open();
        }

        [When(@"(?:User )?[Cc]licks Login button")]
        public void WhenUserClicksLoginButton()
        {
            HomePage.SignInButton.Click();
        }

        [When(@"Enters ""(.*)"" to user name input")]
        public void WhenEntersToUserNameInput(string inputString)
        {
            HomePage.EmailInput.SendKeys(inputString);
        }

        [When(@"Enters ""(.*)"" to password field")]
        public void WhenEntersToPasswordField(string inputString)
        {
            HomePage.PasswordInput.SendKeys(inputString);
        }

        [When(@"Clicks Sign In button on login form")]
        public void WhenClicksSignInButtonOnLoginForm()
        {
            HomePage.SubmitLoginFormButton.Click();
        }

        [Then(@"Login form has error ""(.*)""")]
        public void ThenLoginFormHasError(string expectedErrorMsg)
        {
            var errorMsg = "";
            Assert.DoesNotThrow(() => errorMsg = HomePage.LoginFormError(expectedErrorMsg).Text);
            Assert.That(errorMsg, Is.EqualTo(expectedErrorMsg));
        }
    }
}
