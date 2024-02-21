namespace ParaBankAtf.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;
    using System.Collections.ObjectModel;
    using System;

    //COMMON ACTIONS FOR WEBDRIVER
    /// <summary>
    /// Common actions for WebDriver
    /// This base class contains a useful set of helper methods for scripting Selenium. It should 
    /// encapsulate the common practices and apply sensible programming practices such as DRY.
    /// Keep this code clean & refactored.
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

        public void Back()
        {
            this.Context.Driver.Navigate().Back();
        }

        public Actions GetBuilder()
        {
            return Context.Actions;
        }

        public void NavigateTo(string url)
        {
            this.Context.Driver.Navigate().GoToUrl(url);
        }

        public void RefreshBrowser()
        {
            this.Context.Driver.Navigate().Refresh();
        }

        internal void SendKeyPress(string identifierQuery, string searchCriteria)
        {
            IWebElement element = Context.Driver.FindElement(By.ClassName(identifierQuery));
            element.SendKeys(searchCriteria);
        }

        public IWebElement WaitForElementByClass(string className)
        {
            return this.WaitForVisibility(By.ClassName(className));
        }

        public IWebElement WaitForElementByName(string name)
        {
            return this.WaitForVisibility(By.Name(name));
        }

        // Get by Text
        public string GetTextById(string id)
        {
            return this.Context.Driver.FindElement(By.Id(id)).Text;
        }

        public string GetTextByClass(string className)
        {
            var element = Context.Driver.FindElement(By.ClassName(className));
            return element.Text;
        }

        public string GetTextByCssSelector(string cssSelector)
        {
            return this.WaitForVisibility(By.CssSelector(cssSelector)).Text;
        }

        public string GetTextByName(string name)
        {
            return this.WaitForVisibility(By.Name(name)).Text;
        }

        public string GetInputValueById(string id)
        {
            return this.Context.Driver.FindElement(By.Id(id)).GetAttribute("value");
        }

        public string GetInputValueByName(string name)
        {
            return this.Context.Driver.FindElement(By.Name(name)).GetAttribute("value");
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

        internal void SendKeysSlowly(string IdQuery, string searchCriteria)
        {
            var element = Context.Driver.FindElement(By.Id(IdQuery));
            element.Clear();
            element.SendKeys(searchCriteria);
        }

        public IReadOnlyCollection<IWebElement> GetElementsByTagName(string tagName)
        {
            return Context.Driver.FindElements(By.TagName(tagName));
        }

        public IReadOnlyCollection<IWebElement> GetElementsByXpath(string XPathText)
        {
            return Context.Driver.FindElements(By.XPath(XPathText));
        }   
        
        public IReadOnlyCollection<IWebElement> GetElementsById(string id)
        {
            return Context.Driver.FindElements(By.Id(id));
        }

        public IReadOnlyCollection<IWebElement> GetElementsByName(string name)
        {
            return Context.Driver.FindElements(By.Name(name));
        }

        public string GetTextByXPath(string XPathText)
        {
            WaitForVisibility(By.XPath(XPathText), 10);
            return Context.Driver.FindElement(By.XPath(XPathText)).Text;
        }

        public string GetTextByTagName(string tagName)
        {
            WaitForVisibility(By.TagName(tagName), 10);
            return Context.Driver.FindElement(By.TagName(tagName)).Text;
        }

        public IWebElement GetElement(By byCriterion)
        {
            return Context.Driver.FindElement(byCriterion);
        }

        public ReadOnlyCollection<IWebElement> GetElementsByClassName(string className)
        {
            return Context.Driver.FindElements(By.ClassName(className));
        }

        public ReadOnlyCollection<IWebElement> GetElementsByCssSelector(string CssSelector)
        {
            return Context.Driver.FindElements(By.CssSelector(CssSelector));
        }

        public IWebElement GetElementByClassName(string className)
        {
            return Context.Driver.FindElements(By.ClassName(className))[0];
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

        public string GetElementText(By byCriterion)
        {
            return Context.Driver.FindElement(byCriterion).Text;
        }

        public bool InputElementIsEnabled(By byCriterion)
        {
            var element = Context.Driver.FindElement(byCriterion);
            return element.Enabled;
        }

        public bool ElementHasClass(By byCriterion, string className)
        {
            var element = Context.Driver.FindElement(byCriterion);
            var classes = element.GetAttribute("class");
            return classes.Contains(className);
        }

        public bool ElementIsVisible(By byCriterion)
        {
            var element = Context.Driver.FindElement(byCriterion);
            return element.Displayed;
        }

        public bool IsCheckboxSelected(By checkBox)
        {
            IWebElement Checkbox = Context.Driver.FindElement(checkBox);

            return Checkbox.Selected;
        }

        // Click By
        public void ClickByXPath(string xpathQuery)
        {
            WaitForVisibility(By.XPath(xpathQuery));
            var element = this.Context.Driver.FindElement(By.XPath(xpathQuery));
            Assert.IsNotNull(element);
            element.Click();
        }

        public void ClickByClass(string className)
        {
            WaitForClassToBeVisible(className, 5);
            this.Context.Driver.FindElements(By.ClassName(className)).First().Click();
        }

        public void ClickByTagname(string tagname)
        {
            WaitForVisibility(By.TagName(tagname), 5).Click();

        }

        public void ClickByCssSelector(string css)
        {
            WaitForVisibility(By.CssSelector(css), 5).Click();
        }

        public void ClickByLinkText(string LinkText)
        {
            WaitForVisibility(By.LinkText(LinkText), 10).Click();
        }

        public void ClickById(string id)
        {
            WaitForVisibility(By.Id(id), 10).Click();
        }

        public void ClickByName(string name)
        {
            WaitForVisibility(By.Name(name), 10).Click();
        }

        public void ClickByPartialLinkText(string LinkText)
        {
            WaitForVisibility(By.PartialLinkText(LinkText), 5).Click();
        }

        public void ClickOnElementOffset(By byCriterion, int offX, int offY)
        {
            WaitForVisibility(byCriterion);
            var element = this.Context.Driver.FindElement(byCriterion);
            GetBuilder().MoveToElement(element).MoveByOffset(offX, offY).Click().Perform();
        }

        public string WindowTitle()
        {
            return this.Context.Driver.Title;
        }
        public void ExecuteScript(string script, params object[] args)
        {
            ((IJavaScriptExecutor)this.Context.Driver).ExecuteScript(script, args);
        }

        #region Protected Helper Methods for derived classes

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

        protected IWebElement WaitForClassToBeVisible(string className, int maxWaitSeconds = MaxWaitSeconds)
        {
            return WaitForVisibility(By.ClassName(className), maxWaitSeconds);
        }

        protected IWebElement WaitForIdToBeVisible(string id, int maxWaitSeconds = MaxWaitSeconds)
        {
            return WaitForVisibility(By.Id(id), maxWaitSeconds);
        }
        #endregion
    }
}