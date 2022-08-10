using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;
using BDD.PageObjects;
using FluentAssertions;

namespace BDD.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        public IWebDriver driver { get; set; }

        public IndexFunctions index;
        public LoginFunctions login;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            index = new IndexFunctions(driver);
            login = new LoginFunctions(driver);
        }

        [Given(@"The user is in the main page")]
        public void GivenTheUserIsInTheMainPage()
        {
            index.VisitIndexPage();
            Assert.IsTrue(index.GetTitle() == "Zero - Personal Banking - Loans - Credit Cards");
        }

        [When(@"The user clicks Sign In button")]
        public void WhenTheUserClicksSignInButton()
        {
            if (index.getSignInBtn().Displayed && index.getSignInBtn().Enabled)
            {
                index.ClickSignIn();
                Assert.IsTrue(login.GetTitle() == "Log in to ZeroBank");
                Assert.IsTrue(login.GetURL().Contains("login"));
            }
        }

        [When(@"The user enter ""(.*)"" in the username field")]
        public void WhenTheUserEnterInTheUsernameField(string username)
        {
            login.TypeUsername(username);
        }


        [When(@"The user enter ""(.*)"" in the password field")]
        public void WhenTheUserEnterInThePasswordField(string pass)
        {
            login.TypePassword(pass);
        }


        [When(@"The user enter clicks Sign In button")]
        public void WhenTheUserEnterClicksSignInButton()
        {
            login.ClickSignIn();
        }

        [When(@"The user reload the page")]
        public void WhenTheUserReloadThePage()
        {
            driver.Navigate().Back();
        }

        [Then(@"The user should see his username in the navbar")]
        public void ThenTheUserShouldSeeHisUsernameInTheNavbar()
        {
            index.clickUsername();
            Assert.IsNotNull(index.getLogoutBtn());
        }


        [Then(@"The error messaje is displayed as the following: ""(.*)""")]
        public void ThenTheErrorMessajeIsDisplayedAsTheFollowing(string errorMessage)
        {
            //Assert.IsTrue(login.getErrorLbl().Text.Contains(errorMessage), "The error message should be: 'Login and/or password are wrong.'");
            login.getErrorLbl().Text.Contains(errorMessage).Should().Be(true, "The error message should be: 'Login and/or password are wrong.'");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");

        }

        /// <summary>
        /// Cleanup method for every scenario.
        /// </summary>
        [AfterScenario, Scope(Feature = "Login")]
        public void AfterScenario()
        {
            if (driver != null)
            {
                //driver.Dispose();
            }
        }


    }
}
