using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using dotnetcore_mstest_selenium.Controller;

namespace SeleniumCore
{
    [Binding]
    public class CarrinhoSteps
    {


        IWebDriver _driver;
        CartController cartController;
        ProductController productController;

        public CarrinhoSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["DRIVER"] as IWebDriver;
            cartController = new CartController(scenarioContext);
            productController = new ProductController(scenarioContext);
        }

        [Given(@"que o usuário adcionou ""(.*)"" produto no carrinho")]
        public void DadoQueOUsuarioAdcionouProdutoNoCarrinho(string quantidade)
        {
            var count = 0;
            switch (quantidade)
            {
                case "Um produto":
                    productController.AddToCart();
                    cartController.VerifyCart("1");
                    break;
                case "Três produtos":
                    while (count < 3)
                    {
                        productController.AddToCart();
                        count++;
                    }
                    cartController.VerifyCart("3");
                    break;
            }

        }

        [Given(@"está na pagina do carrinho de compras")]
        public void DadoEstaNaPaginaDoCarrinhoDeCompras()
        {
            cartController.GoToCart();
            cartController.ExisteBtnCheckout();

        }

        [Given(@"que o usuário não adcionou produtos no carrinho")]
        public void DadoQueOUsuarioNaoAdcionouProdutosNoCarrinho()
        {
            cartController.GoToCart();
            cartController.ExisteProdutoNoCarrinho();

        }

        [When(@"Clicar no botão de checkout")]
        public void QuandoClicarNoBotaoDeCheckout()
        {
            cartController.ClicarNoBotaoDeCheckout();

        }

        [Then(@"o sistema não solicitará os dados de entrega")]
        public void EntaoOSistemaNaoSolicitaraOsDadosDeEntrega()
        {
            Assert.IsFalse(_driver.Url.Contains("checkout-step-one.html"));

        }

        [Then(@"o sistema solicitará os dados de entrega")]
        public void EntaoOSistemaSolicitaraOsDadosDeEntrega()
        {
            Assert.IsTrue(_driver.Url.Contains("checkout-step-one.html"));

        }

    }
}
