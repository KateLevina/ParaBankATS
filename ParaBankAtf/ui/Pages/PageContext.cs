namespace ParaBankAtf.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class PageContext
    {
        public PageContext(IWebDriver driver)
        {
            this.Driver = driver;
            Actions = new Actions(this.Driver);
        }

        public IWebDriver Driver { get; private set; }

        public Actions Actions { get; set; }
    }
}