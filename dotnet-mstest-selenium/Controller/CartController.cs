using dotnetcore_mstest_selenium.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using dotnetcore_mstest_selenium.Utils;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace dotnetcore_mstest_selenium.Controller
{
    public class CartController : CommonInterfaceMethods
    {

        IWebDriver _driver;
        CartPage cartPage;
        WebDriverWait wait;


        public CartController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _driver = scenarioContext["DRIVER"] as IWebDriver;
            cartPage = new CartPage();
            wait = scenarioContext["WAIT"] as WebDriverWait;

        }


        public bool VerifyCart(string un)
        {
            var valueCart = _driver.FindElement(cartPage.CartCount);
            if (valueCart.Text == un)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GoToCart()
        {
            var btnCart = _driver.FindElement(cartPage.BtnCart);
            btnCart.Click();
        }

        public bool ExisteBtnCheckout()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(cartPage.BtnCheckout));
            return VerifyExist(cartPage.BtnCheckout, _driver);
        }

        public bool ExisteProdutoNoCarrinho()
        {

            return VerifyExist(cartPage.CartCount, _driver);

        }

        public CartController ClicarNoBotaoDeCheckout()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(cartPage.BtnCheckout));
            var btnCheckout = _driver.FindElement(cartPage.BtnCheckout);
            btnCheckout.Click();

            return this;

        }


    }
}
