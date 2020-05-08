using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using dotnetcore_mstest_selenium.Controller;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Remote;

namespace SeleniumCore.Steps
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver _driver;
        readonly IConfigurationRoot appsettings;
        readonly LoginController loginController;
        readonly string URL, correctUsername, correctPassword, wrongPassword, wrongUsername;
        

        public LoginSteps(ScenarioContext scenarioContext)
        {

            _driver = scenarioContext["DRIVER"] as IWebDriver;
            appsettings = scenarioContext["APPSETTINGS"] as IConfigurationRoot;
            loginController = new LoginController(scenarioContext);
            URL = appsettings.GetSection("baseURL:url").Value;
            correctUsername = appsettings.GetSection("credenciais:correctUsername").Value;
            correctPassword = appsettings.GetSection("credenciais:correctPassword").Value;
            wrongPassword = appsettings.GetSection("credenciais:wrongPassword").Value;
            wrongUsername = appsettings.GetSection("credenciais:wrongUsername").Value;

        }

        [Given(@"que o usuário esteja na página de login")]
        public void DadoQueOUsuarioEstejaNaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl(URL);
            loginController.ExisteBotaoLogin();
        }

        [When(@"informar suas credenciais de acesso corretamente")]
        public void QuandoInformarSuasCredenciaisDeAcessoCorretamente()
        {
            loginController
                .SetUsername(correctUsername)
                .SetPassword(correctPassword)
                .ClickBtnLogin();

        }

        [When(@"informar suas credenciais de acesso ""(.*)""")]
        public void QuandoInformarSuasCredenciaisDeAcesso(string credencialIncorreta)
        {


            switch (credencialIncorreta)
            {
                case "username vazio":
                    loginController
                        .SetUsername("")
                        .SetPassword(correctPassword)
                        .ClickBtnLogin();
                    break;

                case "username inválido":
                    loginController
                        .SetUsername(wrongUsername)
                        .SetPassword(correctPassword)
                        .ClickBtnLogin();
                    break;

                case "senha vazia":
                    loginController
                        .SetUsername(correctUsername)
                        .SetPassword("")
                        .ClickBtnLogin();
                    break;

                case "senha inválida":
                    loginController
                        .SetUsername(correctUsername)
                        .SetPassword(wrongPassword)
                        .ClickBtnLogin();
                    break;
            }

        }

        [Then(@"o sistema apresentará tela de produtos")]
        public void EntaoOSistemaApresentaraTelaDeProdutos()
        {
            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }

        [Then(@"uma mensagem será exibida informando o erro")]
        public void EntaoUmaMensagemSeraExibidaInformandoOErro()
        {

            Assert.IsTrue(loginController.ExisteBotaoErro());

        }

        [Given(@"que o usuário esteja utilizando ""(.*)""")]
        public void DadoQueOUsuarioEstejaUtilizando(string device)
        {
            var hubUri = new Uri("http://localhost:2222/wd/hub");

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            chromeOptions.AddArgument("disable-gpu");
            chromeOptions.PlatformName = "WINDOWS";
            chromeOptions.AddArgument("--start-maximized");            

            switch (device)
            {
                case "Galaxy s5":
                    chromeOptions.EnableMobileEmulation("Galaxy s5");
                    break;                
                   

                case "iPhone 6/7/8 Plus":
                    chromeOptions.EnableMobileEmulation("iPhone 6/7/8 Plus");
                    break;

                case "Pixel 2":
                    chromeOptions.EnableMobileEmulation("Pixel 2");
                    break;
            }

            _driver = new RemoteWebDriver(hubUri, chromeOptions);
            
        }

    }
}