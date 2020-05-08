using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace dotnet_mstest_selenium.Hooks
{
    public class WebDriverFactory
    {
        private String navegador, tipoDeExecucao;
        private IWebDriver _driver;
        private ScenarioContext scenarioContext;

        public WebDriverFactory( string navegador, string tipoDeExecucao, ScenarioContext scenarioContext)
        {
            this.navegador = navegador;
            this.tipoDeExecucao = tipoDeExecucao;
            this.scenarioContext = scenarioContext;
        }

       
        public WebDriverFactory InstanciaWebDriver(string xpto="")
        {            

            if(tipoDeExecucao == "local")
            {
                InstanciaDriverLocal();
            }
            else if(tipoDeExecucao == "remoto")
            {
                InstaciaRemoteDriver();
            }
            return this;
        }

        public IWebDriver InstanciaDriverLocal()
        {
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
            return _driver;
        }


        private IWebDriver InstaciaRemoteDriver()
        {
            var hubUri = new Uri("http://localhost:2222/wd/hub");

            switch(navegador)
            {
                case "Chrome":                
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("headless");
                    chromeOptions.AddArgument("disable-gpu");
                    chromeOptions.PlatformName = "WINDOWS";
                    chromeOptions.AddArgument("--start-maximized");

                    _driver = new RemoteWebDriver(hubUri, chromeOptions);
                    break;


                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                   //firefoxOptions.AddArgument("headless");
                    firefoxOptions.AddArgument("disable-gpu");
                    firefoxOptions.PlatformName = "WINDOWS";
                    firefoxOptions.AddArgument("--start-maximized");

                    _driver = new RemoteWebDriver(hubUri, firefoxOptions);
                    break;
            }
            
            return _driver;



        }     
        
        private ChromeOptions CreateChromeOptions()
        {

            return List<argumentos>;
        }

        public WebDriverFactory InserirNoContextoDoTeste()
        {
            scenarioContext["DRIVER"] = _driver;            
            return this;
        }

        public IWebDriver GetDriver(string xpto ="")
        {
            InstanciaWebDriver(xpto).
                InserirNoContextoDoTeste();
            return _driver;
        }

        


    }
}
