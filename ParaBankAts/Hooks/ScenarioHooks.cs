using BoDi;
using ParaBankAtf.Pages;

namespace ParaBankAts.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer objectContainer;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            objectContainer.RegisterInstanceAs(new PageContext(TestRunContext.Driver));
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}