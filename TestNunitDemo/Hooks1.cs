using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestNunitDemo
{
    [Binding]
    public sealed class Hooks1
    {
        private Page page = new Page();
        [BeforeScenario("Login", "Publish","Draft")]
        public void BeforeScenario()
        {
            page.navigateToURL();
        }

        [AfterScenario("Publish","Draft")]
        public void AfterScenario()
        {
            page.quitBrowser();
        }
    }
}
