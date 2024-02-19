using OpenQA.Selenium;
using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public  class MenuPage: PageBase
    {
        private const string loginButton = "//input[@class='button' and @type='submit']";

        public MenuPage(PageContext context) : base(context) { }

        private void ClickMenuItem(string text)
        {
            ClickByPartialLinkText(text);
        }

        public void Login(string login, string password)
        {
            //if not logged in yet
            if (ElementExists(By.XPath(loginButton)))
            {
                EnterTextIntoTextBox(By.Name("username"), login);
                EnterTextIntoTextBox(By.Name("password"), password);
                ClickByXPath(loginButton);
            }
        }

        public void LogOut()
        {
            ClickByPartialLinkText("Log Out");
        }

        public void OpenFindTransactions()
        {
            ClickMenuItem("Find Transactions");
        }

        public void OpenAccountOverview()
        {
            ClickMenuItem("Accounts Overview");
        }
    }
}
