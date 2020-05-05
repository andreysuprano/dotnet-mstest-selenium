using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace dotnetcore_mstest_selenium.Pages
{
    class LoginPage
    {

        public By InputUsername => By.Id("user-name");

        public By InputPassword => By.Id("password");

        public By LoginButton => By.ClassName("btn_action");

        public By LoginButtonError => By.ClassName("error-button");

    }
}
