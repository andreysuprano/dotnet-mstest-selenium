using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetcore_mstest_selenium.Pages
{
    public class CartPage
    {
        public By BtnAddToCart => By.XPath("//button[contains(text(), 'ADD TO CART')]");

        public By CartCount => By.XPath("//div[@id = 'shopping_cart_container']/a/span");

        public By BtnCart => By.XPath("//div[@id= 'shopping_cart_container'] /a");

        public By BtnCheckout => By.ClassName("checkout_button");



    }
}
