using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using dotnet_mstest_selenium.Hooks;

namespace SeleniumCore.Hooks
{
    [Binding]
    class Hooks
    {
        IWebDriver _driver;
        [BeforeScenario]
        public void IniciaNavegacao(ScenarioContext scenarioContext)
        {
            var msContext = scenarioContext.ScenarioContainer.Resolve<TestContext>();            
            var ambiente = msContext.Properties["ambiente"].ToString();
            var navegador = msContext.Properties["navegador"].ToString();
            var tipoDeExecucao = msContext.Properties["tipoDeExecucao"].ToString();
            
            var driver = new WebDriverFactory(navegador, tipoDeExecucao, scenarioContext);
            _driver = driver.GetDriver();


            var outPutDirectory =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);            

            var appsettings = new ConfigurationBuilder().AddJsonFile(outPutDirectory + "\\appsettings." + ambiente + ".json").Build();
            scenarioContext["APPSETTINGS"] = appsettings;

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            scenarioContext["WAIT"] = wait;

        }

        [BeforeScenario ("TesteDevice")]
        public void IniciaNavegacaoTesteDevice(ScenarioContext scenarioContext)
        {
            var msContext = scenarioContext.ScenarioContainer.Resolve<TestContext>();
            var ambiente = msContext.Properties["ambiente"].ToString();

            var outPutDirectory =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var appsettings = new ConfigurationBuilder().AddJsonFile(outPutDirectory + "\\appsettings." + ambiente + ".json").Build();
            scenarioContext["APPSETTINGS"] = appsettings;

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            scenarioContext["WAIT"] = wait;

        }



        [AfterScenario]
        public void QuitDriver()
        {            
            _driver.Quit();
        }

    }
}
