using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebDriverBasics
{
    [Binding]
    class LogOffSteps : BaseTest
    {
        YandexMainPage yandexMainPage;

        [Given(@"I login with valid (.*) and (.*)")]
        public void GivenILoginWithValidAnd(string username, string password)
        {
            yandexMainPage = LoginPage.LoginAs(username, password);
        }

        [When(@"I press log off button")]
        public void WhenIPressLogOffButton()
        {
            LoginPage = yandexMainPage.LogOff();
        }

        [Then(@"I on yandex login page")]
        public void ThenIOnYandexLoginPage()
        {
            Assert.IsTrue(LoginPage.LoginIntoButton.Displayed);
        }
    }
}
