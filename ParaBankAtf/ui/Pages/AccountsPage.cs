using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public  class AccountsPage: PageBase
    {
        protected string accountByOrder(int accountRowNumber) => $"//table[@id='accountTable']//tr['{accountRowNumber}']/td[1]/a";
        public AccountsPage(PageContext context) : base(context) { }

        public void OpenAccountDetails(int rowNumber)
        {
            ClickByXPath(accountByOrder(rowNumber));
        }
    }
}
