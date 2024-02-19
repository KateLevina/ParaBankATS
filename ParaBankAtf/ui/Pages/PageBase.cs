namespace ParaBankAtf.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;

    /// <summary>
    /// Common actions for WebDriver
    /// This base class contains a useful set of helper methods for scripting Selenium. 
    /// </summary>
    public class PageBase
    {
        protected readonly PageContext Context;
        private const int MaxWaitSeconds = 10;

        public PageBase(PageContext context)
        {
            this.Context = context;
        }

        public string GetCurrentUrl()
        {
            return Context.Driver.Url;
        }

        public Actions GetBuilder()
        {
            return Context.Actions;
        }

        public void NavigateTo(string url)
        {
            this.Context.Driver.Navigate().GoToUrl(url);
        }

        public void EnterTextIntoTextBox(By criteria, string text, bool addEnter = false)
        {
            WaitForVisibility(criteria, 2);
            var element = Context.Driver.FindElement(criteria);
            element.Click();
            element.Clear();
            element.SendKeys(text);

            if (addEnter)
            {
                element.SendKeys(Keys.Enter);
            }
        }

        public IReadOnlyCollection<IWebElement> GetElementsById(string id)
        {
            return Context.Driver.FindElements(By.Id(id));
        }

        public IWebElement GetElement(By byCriterion)
        {
            return Context.Driver.FindElement(byCriterion);
        }

        public bool ElementExists(By byCriterion)
        {
            try
            {
                Context.Driver.FindElement(byCriterion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Click By
        public void ClickByXPath(string xpathQuery)
        {
            WaitForVisibility(By.XPath(xpathQuery));
            var element = this.Context.Driver.FindElement(By.XPath(xpathQuery));
            Assert.IsNotNull(element);
            element.Click();
        }

        public void ClickByPartialLinkText(string LinkText)
        {
            WaitForVisibility(By.PartialLinkText(LinkText), 5).Click();
        }

        /// <summary>
        /// Refactored all the "wait for this & that to be visible" stuff into a couple 
        /// of tiny methods
        /// </summary>
        /// <param name="byCriterion"></param>
        /// <param name="maxWaitSeconds"></param>
        public IWebElement WaitForVisibility(By byCriterion, int maxWaitSeconds = MaxWaitSeconds)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(maxWaitSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(byCriterion));
        }
    }
}
