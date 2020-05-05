using dotnetcore_mstest_selenium.Pages;
using dotnetcore_mstest_selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace dotnetcore_mstest_selenium.Controller
{
    public class ProductController : CommonInterfaceMethods
    {

        IWebDriver _driver;
        CartPage cartPage;
        WebDriverWait wait;


        public ProductController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _driver = scenarioContext["DRIVER"] as IWebDriver;
            cartPage = new CartPage();
            wait = scenarioContext["WAIT"] as WebDriverWait;

        }

        public ProductController IsOnProductPage()
        {
            return this;
        }

        public ProductController AddToCart()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(cartPage.BtnAddToCart));
            var btnAddToCart = _driver.FindElement(cartPage.BtnAddToCart);

            btnAddToCart.Click();

            return this;
        }
    }
}
