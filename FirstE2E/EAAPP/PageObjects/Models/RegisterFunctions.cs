using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using EAAPP.Util;

namespace BDD.PageObjects
{
    public class RegisterFunctions: RegisterPage
    {

        public RegisterFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetURL()
        {
            return driver.Url;
        }

        public string GetTitle()
        {
            var waitTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitTitle.Until(ExpectedConditions.ElementIsVisible(this.Title));
            return this.RegisterTitle.Text;
        }

        public void TypeUsername(string username)
        {
            this.UserNameTxt.SendKeys(username);
        }

        public void TypePassword(string password)
        {
            this.PasswordTxt.SendKeys(password);
        }

        public void TypeConfirmPassword(string password)
        {
            this.ConfirmPasswordTxt.SendKeys(password);
        }

        public void TypeEmail(string email)
        {
            this.EmailTxt.SendKeys(email);
        }

        public void ClickRegister()
        {
            this.RegisterBtn.Click();
        }

        public IWebElement getSingleFieldErrorLbl()
        {
            Util.WaitForElement(this.Title, this.driver, 2);
            return this.SingleFieldErrorLbl;
        }

        public IWebElement getUsernameErrorLbl()
        {
            Util.WaitForElement(this.Title, this.driver, 2);
            return this.UsernameErrorLbl;
        }

        public IWebElement getPasswordErrorLbl()
        {
            Util.WaitForElement(this.Title, this.driver, 2);
            return this.PasswordErrorLbl;
        }

        public IWebElement getEmailErrorLbl()
        {
            Util.WaitForElement(this.Title, this.driver, 2);
            return this.EmailErrorLbl;
        }

    }
}
