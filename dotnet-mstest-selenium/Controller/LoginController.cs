using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using dotnetcore_mstest_selenium.Pages;
using dotnetcore_mstest_selenium.Utils;

namespace dotnetcore_mstest_selenium.Controller
{
    public class LoginController : CommonInterfaceMethods
    {

        readonly IWebDriver _driver;
        readonly LoginPage loginPage;
        readonly ScenarioContext contexto;


        public LoginController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            contexto = scenarioContext;
            _driver = scenarioContext["DRIVER"] as IWebDriver;
            loginPage = new LoginPage();

        }

        public LoginController SetUsername(string username)
        {
            _driver.FindElement(loginPage.InputUsername).SendKeys(username);
            return this;
        }

        public bool ExisteBotaoLogin()
        {
            return VerifyExist(loginPage.LoginButton, _driver);

        }
        public LoginController SetPassword(string password)
        {
            _driver.FindElement(loginPage.InputPassword).SendKeys(password);
            return this;
        }

        public ProductController ClickBtnLogin()
        {
            _driver.FindElement(loginPage.LoginButton).Click();
            return new ProductController(contexto);
        }

        public bool ExisteBotaoErro()
        {
            return VerifyExist(loginPage.LoginButtonError, _driver);

        }

    }
}
