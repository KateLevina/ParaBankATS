using NUnit.Framework;
using ParaBankAtf.api;
using ParaBankAtf.ui.Pages;

namespace ParaBankAts.StepDefinitions
{
    [Binding]
    public class FindTransactionsStepDefinitions
    {
        private FindTransactionPage _findFTransactionPage;
        MenuPage _menuPage;

        public FindTransactionsStepDefinitions(MenuPage menuPage, FindTransactionPage findFTransactionPage)
        {
            _menuPage = menuPage;
            _findFTransactionPage = findFTransactionPage;
        }

        [Given(@"(.*) accounts are created for user - Acc(.*), Acc(.*) and made transactions")]
        public void GivenAccountsAreCreatedForUser_AccAccAndMadeTransactions(int p0, int p1, int p2, Table table)
        {
            var api = new AccountApi();
            api.PerpareFindTransactionsData();
        }

        [When(@"Acc(.*) is selected in Account combobox")]
        public void WhenAccIsSelectedInAccountCombobox(string p0)
        {
            _findFTransactionPage.SelectAccount(p0);
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
            _menuPage.Login("john", "demo");
            _menuPage.OpenFindTransactions();
            _findFTransactionPage.SetAmountValue(p0);
        }

        [Then(@"Transaction table is not empty")]
        public void ThenTransactionTableIsNotEmpty()
        {
            _findFTransactionPage.CheckTransactionsTableNotEmpty();
        }
    }
}
