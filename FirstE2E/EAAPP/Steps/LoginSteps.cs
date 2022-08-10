using System;
using BDD.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EAAPP.Steps
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver { get; set; }

        private readonly ScenarioContext _scenarioContext;

        public IndexFunctions index;
        
        public LoginFunctions login;

        public LoginSteps(ScenarioContext scenarioContext)
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
            Assert.IsTrue(index.GetTitle() == "Home - Execute Automation Employee App");
        }

        [When(@"The user clicks Log In option")]
        public void WhenTheUserClicksLogInOption()
        {
            if (index.getLogInBtn().Displayed && index.getLogInBtn().Enabled)
            {
                index.ClickLogIn();
                Assert.IsTrue(login.GetTitle().Contains("Login"));
                Assert.IsTrue(login.GetURL().Contains("Login"));
            }
        }

        [When(@"The user enter ""(.*)"" in the username field")]
        public void WhenTheUserEnterInTheUsernameField(string username)
        {
            login.TypeUsername(username);
        }

        [When(@"The user clicks Log In button")]
        public void WhenTheUserClicksLogInButton()
        {
            login.ClickLogIn();
        }

        [When(@"The user enter ""(.*)"" in the password field")]
        public void WhenTheUserEnterInThePasswordField(string pass)
        {
            login.TypePassword(pass);
        }

        [Then(@"The user should see his username in the navbar")]
        public void ThenTheUserShouldSeeHisUsernameInTheNavbar()
        {
            index.clickUsername();
            Assert.IsNotNull(index.getLogOutBtn());
        }
        
        [Then(@"The error messaje is displayed as the following: ""(.*)""")]
        public void ThenTheErrorMessajeIsDisplayedAsTheFollowing(string errorMessage)
        {
            login.getAttemptErrorLbl().Text.Contains(errorMessage).Should().Be(true, "The error message should be: 'Login and/or password are wrong.'");
        }

        [AfterScenario, Scope(Feature = "Login")]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                //driver = null;
            }
        }
    }
}
