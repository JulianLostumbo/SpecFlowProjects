using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using EAAPP.Util;

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

        public string GetUrl()
        {
            return this.Url;
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickLogIn()
        {
            Util.WaitForElement(this.Login, this.driver, 2);
            this.LogInBtn.Click();
        }

        public void ClickRegister()
        {
            Util.WaitForElement(this.Register, this.driver, 2);
            this.RegisterBtn.Click();
        }

        public void clickUsername()
        {
           this.ManageUserBtn.Click();
        }

        public IWebElement getLogOutBtn()
        {
            Util.WaitForElement(this.Logoff, this.driver, 2);
            return this.LogOffBtn;
        }
        public IWebElement getLogInBtn()
        {
            return this.LogInBtn;
        }

        public IWebElement getWelcomeMessage()
        {
            return this.ManageUserBtn;
        }
    }
}
