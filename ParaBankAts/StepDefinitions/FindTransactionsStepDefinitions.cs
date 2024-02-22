using NUnit.Framework;
using ParaBankAtf.api;
using ParaBankAtf.ui.Pages;

namespace ParaBankAts.StepDefinitions
{
    [Binding]
    public class FindTransactionsStepDefinitions
    {
        private FindTransactionPage _findFTransactionPage;
        private MenuPage _menu;

        public FindTransactionsStepDefinitions(MenuPage menu, FindTransactionPage findFTransactionPage)
        {
            _menu = menu;
            _findFTransactionPage = findFTransactionPage;
        }

        [Given(@"Accounts are created for user - Acc1, Acc2 and made transactions")]
        public void GivenAccountsAreCreatedForUser_AccAccAndMadeTransactions()
        {
            var api = new AccountApi();
            api.PerpareFindTransactionsData();
        }

        [When(@"Last created account is selected in Account combobox")]
        public void WhenAccIsSelectedInAccountCombobox()
        {
            _findFTransactionPage.SelectAccount();
        }

        [When(@"Corresponding Find Transactions Button is clicked")]
        public void WhenCorrespondingFindTransactionsButtonIsClicked()
        {
            _findFTransactionPage.ClickFindByAmountBtn();
        }

        [Then(@"Transactions page is opened")]
        public void ThenTransactionsPageIsOpened()
        {
            Assert.IsTrue(_findFTransactionPage.VerifyTransactionPageUrl(), "Find Transactions page url was expected");
        }

        [When(@"Amount is specified with (.*)")]
        public void WhenCriteriaIsSpecifiedWith(string p0)
        {
            _menu.Login("john", "demo");
            _menu.OpenFindTransactions();
            _findFTransactionPage.SetAmountValue(p0);
        }

        [Then(@"Transaction table is not empty")]
        public void ThenTransactionTableIsNotEmpty()
        {
            _findFTransactionPage.CheckTransactionsTableNotEmpty();
        }
    }
}
