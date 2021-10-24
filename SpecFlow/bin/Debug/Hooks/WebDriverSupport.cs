using System;
using BoDi;
using Selenium.Pages;
using Selenium.Support;
using TechTalk.SpecFlow;

namespace SpecFlow.Hooks
{
    [Binding]
    public class WebDriverSupport : IDisposable
    {
        private readonly IObjectContainer objectContainer;
        private AutomationTestSite automationTestSite;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            automationTestSite = new AutomationTestSite();
            objectContainer.RegisterInstanceAs(automationTestSite);   
        }

        [AfterScenario]
        public void Dispose()
        {
            automationTestSite?.Dispose();
        }

    }
}
