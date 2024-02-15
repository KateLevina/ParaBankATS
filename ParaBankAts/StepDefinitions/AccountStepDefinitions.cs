using ParaBankAtf.ui.Pages;

namespace ParaBankAts.StepDefinitions
{
    [Binding]
    public class AccountStepDefinitions
    {
        private LoginPage _loginPage;
        public AccountStepDefinitions(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given(@"user with several accounts is logged in")]
        public void GivenUserWithSeveralAccountsIsLoggedIn()
        {
            _loginPage.Login("kate", "qwerty");
        }

        [When(@"User navigates to Account Overview")]
        public void WhenUserNavigatesToAccountOverview()
        {
            throw new PendingStepException();
        }

        [When(@"Clicks on Account number link")]
        public void WhenClicksOnAccountNumberLink()
        {
            throw new PendingStepException();
        }

        [Then(@"details page is displayed")]
        public void ThenDetailsPageIsDisplayed()
        {
            throw new PendingStepException();
        }

        [Then(@"(.*) value is not empty")]
        public void ThenAvailableValueIsNotEmpty(string field)
        {
            throw new PendingStepException();
        }
    }
}
