using OpenQA.Selenium;
using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public class AccountDetailsPage: PageBase
    {
        private const string AccoutDetailsTitle = "//*[@class='title' and text()='Account Details']";
        public string FilterOptionAll(string filterType) => $"//select[@id='{filterType}']/option[@selected='selected' and @value='All']";
        public AccountDetailsPage(PageContext context) : base(context) { }

        public bool CheckAccountDetailsTitleIsShown()
        {
            return ElementIsVisibleByXPath(AccoutDetailsTitle);
        }

        public bool CheckFieldValueIsNotEmpty(string field)
        {
            IWebElement? valueElement = null;
            switch (field)
            {
                case "Account Number":
                    valueElement = GetElementsById("accountId").FirstOrDefault();
                    break;
                case "Account Type":
                    valueElement = GetElementsById("accountType").FirstOrDefault();
                    break;
                case "Balance":
                    valueElement = GetElementsById("balance").FirstOrDefault();
                    break;
                case "Available":
                    valueElement = GetElementsById("availableBalance").FirstOrDefault();
                    break;
            }

            return valueElement != null;
        }

        public bool CheckFilterValuesAreDefault(string xPath)
        {
            return (GetElement(By.XPath(xPath)) != null);
        }
    }
}
