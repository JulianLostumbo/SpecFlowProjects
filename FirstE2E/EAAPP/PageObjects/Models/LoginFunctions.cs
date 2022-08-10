using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using EAAPP.Util;

namespace BDD.PageObjects
{
    public class LoginFunctions: LoginPage
    {

        public LoginFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetURL()
        {
            return driver.Url;
        }

        public string GetTitle()
        {
            Util.WaitForElement(this.Title, this.driver, 2);
            return this.LoginTitle.Text;
        }

        public void TypeUsername(string username)
        {
            this.UserNameTxt.SendKeys(username);
        }

        public void TypePassword(string password)
        {
            this.PasswordTxt.SendKeys(password);
        }

        public void ClickLogIn()
        {
            this.LoginBtn.Click();
        }

        public IWebElement getAttemptErrorLbl()
        {
            return this.AttemptErrorLbl;
        }

        public IWebElement getUsernameErrorLbl()
        {
            return this.UsernameErrorLbl;
        }

        public IWebElement getPasswordErrorLbl()
        {
            return this.PasswordErrorLbl;
        }

    }
}
