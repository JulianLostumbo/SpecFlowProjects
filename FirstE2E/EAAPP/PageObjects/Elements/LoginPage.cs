using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.PageObjects
{
    public class LoginPage
    {
        protected IWebDriver driver { get; set; }

        protected By Title => By.TagName("h2");

        protected By Username => By.Id("UserName");

        protected By Password => By.Id("Password");

        protected By Login => By.CssSelector("input[value=\"Log in \"]");

        protected By UsernameError => By.CssSelector(".field-validation-error > span[for=\"UserName\"]");

        protected By PasswordError => By.CssSelector(".field-validation-error > span[for=\"Password\"]");

        protected By AttemptError => By.CssSelector(".validation-summary-errors li");

        protected IWebElement LoginTitle => driver.FindElement(Title);

        protected IWebElement UserNameTxt => driver.FindElement(Username);

        protected IWebElement PasswordTxt => driver.FindElement(Password);

        protected IWebElement LoginBtn => driver.FindElement(Login);

        protected IWebElement UsernameErrorLbl => driver.FindElement(UsernameError);

        protected IWebElement PasswordErrorLbl => driver.FindElement(PasswordError);

        protected IWebElement AttemptErrorLbl => driver.FindElement(AttemptError);



    }
}
