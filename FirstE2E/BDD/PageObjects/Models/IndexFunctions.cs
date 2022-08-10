using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.PageObjects
{
    public class IndexFunctions: IndexPage
    {

        public IndexFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void VisitIndexPage()
        {
            driver.Navigate().GoToUrl(this.Url);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickSignIn(string password)
        {
            var waitSignIn = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitSignIn.Until(ExpectedConditions.ElementIsVisible(this.SignIn));
            this.SignInBtn.Click();

        }

        public void ClickSignIn()
        {
            this.SignInBtn.Click();
        }

        public void clickUsername()
        {
           this.UsernameToggle.Click();
        }

        public IWebElement getLogoutBtn()
        {
            return this.LogOutBtn;
        }
        public IWebElement getSignInBtn()
        {
            return this.SignInBtn;
        }
    }
}
