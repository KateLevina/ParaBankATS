using NUnit.Framework;
using ParaBankAtf.ui.Pages;

namespace ParaBankAts.StepDefinitions
{
    [Binding]
    public class AccountStepDefinitions
    {
        private AccountsPage _accountsPage;
        private AccountDetailsPage _accountDetailsPage;
        private MenuPage _menu;
        public AccountStepDefinitions(MenuPage menu, AccountsPage accountsPage, AccountDetailsPage accountDetailsPage)
        {
            _menu = menu;
            _accountsPage = accountsPage;
            _accountDetailsPage = accountDetailsPage;
        }

        [Given(@"user with several accounts is logged in")]
        public void GivenUserWithSeveralAccountsIsLoggedIn()
        {
            _menu.Login("john", "demo");
        }

        [When(@"User navigates to Account Overview")]
        public void WhenUserNavigatesToAccountOverview()
        {
            _menu.OpenAccountOverview();
        }

        [Then(@"details page is displayed")]
        public void ThenDetailsPageIsDisplayed()
        {
            Assert.IsTrue(_accountDetailsPage.CheckAccountDetailsTitleIsShown(), "Account Details title is to be shown but it was not found");
        }

        [Then(@"(.*) value is not empty")]
        public void ThenAvailableValueIsNotEmpty(string field)
        {
            Assert.IsTrue(_accountDetailsPage.CheckFieldValueIsNotEmpty(field), $"The {field} value of Account Details is not shown");
        }

        [When(@"Clicks on Account number link in the (.*) row of table")]
        public void WhenClicksOnAccountNumberLinkInTheRowOfTable(int rowNo)
        {
            _accountsPage.OpenAccountDetails(rowNo);
        }

        [Then(@"Account Activity filter values are set to All")]
        public void ThenAccountActivityFilterValuesAreSetToAll()
        {
            Assert.IsTrue(_accountDetailsPage.CheckFilterValuesAreDefault(_accountDetailsPage.FilterOptionAll("month")), "Activity Perion filter value is expected to be 'All'");
            Assert.IsTrue(_accountDetailsPage.CheckFilterValuesAreDefault(_accountDetailsPage.FilterOptionAll("transactionType")), "Type filer value is expected to be 'All'");
        }
    }
}
