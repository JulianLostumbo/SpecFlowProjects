using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.PageObjects
{
    public class RegisterPage
    {
        protected IWebDriver driver { get; set; }

        protected By Title => By.TagName("h2");

        protected By Username => By.Id("UserName");

        protected By Password => By.Id("Password");

        protected By ConfirmPassword => By.Id("ConfirmPassword");

        protected By Email => By.Id("Email");


        protected By Register => By.CssSelector("input[value=\"Register\"]");

        protected By UsernameEmptyError => By.CssSelector(".validation-summary-errors li:nth-child(1)");

        protected By PasswordEmptyError => By.CssSelector(".validation-summary-errors li:nth-child(2)");

        protected By EmailEmptyError => By.CssSelector(".validation-summary-errors li:nth-child(3)");

        protected By SingleFieldError => By.CssSelector(".validation-summary-errors li");

        protected IWebElement RegisterTitle => driver.FindElement(Title);

        protected IWebElement UserNameTxt => driver.FindElement(Username);

        protected IWebElement PasswordTxt => driver.FindElement(Password);

        protected IWebElement ConfirmPasswordTxt => driver.FindElement(ConfirmPassword);

        protected IWebElement EmailTxt => driver.FindElement(Email);

        protected IWebElement RegisterBtn => driver.FindElement(Register);

        protected IWebElement UsernameErrorLbl => driver.FindElement(UsernameEmptyError);

        protected IWebElement PasswordErrorLbl => driver.FindElement(PasswordEmptyError);

        protected IWebElement EmailErrorLbl => driver.FindElement(EmailEmptyError);

        protected IWebElement  SingleFieldErrorLbl => driver.FindElement(SingleFieldError);



    }
}
