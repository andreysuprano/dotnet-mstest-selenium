using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace dotnetcore_mstest_selenium.Utils
{
    public class CommonInterfaceMethods
    {
        static WebDriverWait wait;
        public CommonInterfaceMethods(ScenarioContext scenarioContext)
        {
            wait = scenarioContext["WAIT"] as WebDriverWait;

        }

        public bool VerifyExist(By Paramlocator, IWebDriver _driver)
        {
            var contexto = _driver;
            bool isDisplayed = false;
            try
            {

                isDisplayed = wait.Until(ExpectedConditions.ElementExists(Paramlocator)).Displayed;

            }
            catch (Exception e)
            {
                Console.Out.WriteLine($"Elemeto com locator {Paramlocator} não foi localizado na tela causado por {e.Message}");
            }
            return isDisplayed;

        }

    }
}
