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

        private string _Url = "http://zero.webappsecurity.com/index.html";

        protected string Url
        {
            get
            {
                return _Url;
            }
        }

        protected By SignIn => By.ClassName("signin");

        protected By Username => By.XPath("//li[3]/a[@class='dropdown-toggle']");

        protected By Logout => By.Id("logout_link");

        protected IWebElement SignInBtn => driver.FindElement(this.SignIn);

        protected IWebElement UsernameToggle => driver.FindElement(this.Username);

        protected IWebElement LogOutBtn => driver.FindElement(this.Logout);

    }
}
