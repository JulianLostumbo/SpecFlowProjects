using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.PageObjects
{
    public class IndexPage
    {
        protected IWebDriver driver { get; set; }

        private string _Url = "http://eaapp.somee.com/";

        protected string Url
        {
            get
            {
                return _Url;
            }
        }

        protected By Login => By.Id("loginLink");

        protected By Register => By.Id("registerLink");

        protected By EmployeeList => By.XPath("a[contains(@href,'Employee')]");

        protected By Logoff => By.LinkText("Log off");

        protected By WelcomeMessage => By.CssSelector("a[title='Manage']");

        protected IWebElement LogInBtn => driver.FindElement(this.Login);

        protected IWebElement RegisterBtn => driver.FindElement(this.Register);

        protected IWebElement ManageUserBtn => driver.FindElement(this.WelcomeMessage);

        protected IWebElement LogOffBtn => driver.FindElement(this.Logoff);

    }
}
