using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
            var waitTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitTitle.Until(ExpectedConditions.ElementIsVisible(this.Title));
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

        public void ClickSignIn()
        {
            this.SignInBtn.Click();
        }

        public IWebElement getErrorLbl()
        {
            return this.ErrorLbl;
        }

    }
}
