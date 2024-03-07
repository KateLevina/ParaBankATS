using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public class FindTransactionPage: PageBase
    {
        private const string TransactionsTableRows = "//table[@id='transactionTable']/tbody/tr";
        private const string FindByAmountBtn = "(//button[@type='submit'])[last()]";
        public FindTransactionPage(PageContext context) : base(context) { }

        public void ClickFindByAmountBtn()
        {
            ClickByXPath(FindByAmountBtn);
        }

        public void SetAmountValue(string p0)
        {
            EnterTextIntoTextBox(By.Id("criteria.amount"), p0);
        }

        public bool VerifyTransactionPageUrl()
        {
            return GetCurrentUrl().Contains("findtrans.htm");
        }

        public void SelectAccount()
        {
            SelectElement dropDown = new SelectElement(Context.Driver.FindElement(By.Id("accountId")));
            dropDown.SelectByIndex(dropDown.Options.Count-1);
        }

        public void CheckTransactionsTableNotEmpty()
        {
            WaitForVisibility(By.XPath(TransactionsTableRows));
            int rowCount = GetElementsByXpath(TransactionsTableRows).Count;
            Assert.Greater(rowCount, 0, "Transactions table is empty");
        }
    }
}
