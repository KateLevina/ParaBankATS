using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public class FindTransactionPage: PageBase
    {
        private string _transactionsTableRows = "//*[@id='transactionTable']/tbody/tr";
        private string _findByAmountBtn = "(//button[@type='submit'])[last()]";
        public FindTransactionPage(PageContext context) : base(context) { }

        public void ClickFindByAmountBtn()
        {
            ClickByXPath(_findByAmountBtn);
        }

        public void SetAmountValue(string p0)
        {
            EnterTextIntoTextBox(By.Id("criteria.amount"), p0);
        }

        public bool VerifyTransactionPageUrl()
        {
            return GetCurrentUrl().Contains("findtrans.htm");
        }

        public void SelectAccount(string p0)
        {
            SelectElement dropDown = new SelectElement(this.Context.Driver.FindElement(By.Id("accountId")));
            dropDown.SelectByIndex(dropDown.Options.Count-1);
        }

        public void CheckTransactionsTableNotEmpty()
        {
            WaitForVisibility(By.XPath(_transactionsTableRows));
            int rowCount = GetElementsByXpath(_transactionsTableRows).Count;
            Assert.Greater(rowCount, 0, "Transactions table is empty");
        }
    }
}
