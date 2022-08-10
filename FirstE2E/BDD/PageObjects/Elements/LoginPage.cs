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

        protected By Title => By.TagName("h3");

        protected By Username => By.Id("user_login");


        protected By Password => By.Id("user_password");

        protected By SignIn => By.XPath("//input[@type='submit' and @value='Sign in']");//By.ClassName("btn-primary");

        protected By Error => By.ClassName("alert-error");

        protected IWebElement LoginTitle => driver.FindElement(Title);

        protected IWebElement UserNameTxt => driver.FindElement(Username);

        protected IWebElement PasswordTxt => driver.FindElement(Password);

        protected IWebElement SignInBtn => driver.FindElement(SignIn);

        protected IWebElement ErrorLbl => driver.FindElement(Error);


    }
}
