namespace ParaBankAts.Hooks
{
    using BoDi;
    using ParaBankAtf.Pages;

    [Binding]
    public class ScenarioHooks
    {
        private const string DefaultPage = "http://localhost:8080/parabank";
        private readonly IObjectContainer objectContainer;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.objectContainer.RegisterInstanceAs(new PageContext(TestRunContext.Driver));
            TestRunContext.Driver.Navigate().GoToUrl(DefaultPage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}