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
            var navegador = msContext.Properties["navegador"].ToString();
            var ambiente = msContext.Properties["ambiente"].ToString();
            var outPutDirectory =
               Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (navegador)
            {
                case "Chrome":
                    _driver = new ChromeDriver(outPutDirectory);
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver(outPutDirectory);
                    break;
            }

            scenarioContext["DRIVER"] = _driver;

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            scenarioContext["WAIT"] = wait;

            var appsettings = new ConfigurationBuilder().AddJsonFile(outPutDirectory + "\\appsettings." + ambiente + ".json").Build();
            scenarioContext["APPSETTINGS"] = appsettings;

        }



        [AfterScenario]
        public void QuitDriver()
        {
            _driver.Quit();
        }

    }
}
