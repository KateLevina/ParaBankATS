using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ParaBankAtf.Pages
{
    public class PageContext
    {
        public PageContext(IWebDriver driver)
        {
            Driver = driver;
            Actions = new Actions(Driver);
        }

        public IWebDriver Driver { get; private set; }

        public Actions Actions { get; set; }
    }
}