using OpenQA.Selenium;
using ParaBankAtf.Pages;

namespace ParaBankAtf.ui.Pages
{
    public  class LoginPage: PageBase
    {
        public LoginPage(PageContext context) : base(context) { }

        public void Login(string login, string password)
        {
            EnterTextIntoTextBox(By.Name("username"), login);
            EnterTextIntoTextBox(By.Name("password"), password);
            ClickByXPath($"//input[@class='button' and @type='submit']");
        }

        public void OpenAccountOverview()
        {
            
        }
    }
}
