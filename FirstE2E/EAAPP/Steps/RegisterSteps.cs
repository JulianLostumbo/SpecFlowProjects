using System;
using BDD.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EAAPP.Steps
{
    [Binding]
    public class RegisterSteps
    {
        public IWebDriver driver { get; set; }

        private readonly ScenarioContext _scenarioContext;

        public IndexFunctions index;

        public RegisterFunctions register;

        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            index = new IndexFunctions(driver);
            register = new RegisterFunctions(driver);
        }

        [When(@"The user clicks Register button in the navbar")]
        public void WhenTheUserClicksRegisterButtonInTheNavbar()
        {
            index.ClickRegister();
            Assert.IsTrue(register.GetTitle().Contains("Register"));
            Assert.IsTrue(register.GetURL().Contains("Register"));
        }

        [When(@"The user enter ""(.*)"" in the username field for registration")]
        public void WhenTheUserEnterInTheUsernameFieldForRegistration(string username)
        {
            register.TypeUsername(username);
        }

        [When(@"The user enter ""(.*)"" in the password field for registration")]
        public void WhenTheUserEnterInThePasswordFieldForRegistration(string pass)
        {
            register.TypePassword(pass);
        }

        [When(@"The user enter ""(.*)"" in the confirm password field for registration")]
        public void WhenTheUserEnterInTheConfirmPasswordFieldForRegistration(string pass)
        {
            register.TypeConfirmPassword(pass);
        }

        [When(@"The user enter ""(.*)"" in the email field for registration")]
        public void WhenTheUserEnterInTheEmailFieldForRegistration(string email)
        {
            register.TypeEmail(email);
        }

        [When(@"The user clicks Register button")]
        public void WhenTheUserClicksRegisterButton()
        {
            register.ClickRegister();
        }
        
        [When(@"The user enter ""(.*)"" in the confirm password field")]
        public void WhenTheUserEnterInTheConfirmPasswordField(string pass)
        {
            register.TypeConfirmPassword(pass);
        }
        
        [Then(@"The user is redirected to the main page")]
        public void ThenTheUserIsRedirectedToTheMainPage()
        {
            Assert.IsTrue(driver.Url == index.GetUrl());
        }
        
        [Then(@"The user sees the message ""(.*)"" in the navbar")]
        public void ThenTheUserSeesTheMessageInTheNavbar(string message)
        {
            Assert.IsTrue(index.getWelcomeMessage().Displayed);
            Assert.IsTrue(index.getWelcomeMessage().Text.Contains(message));
        }

        [Then(@"The user see the following error message: ""(.*)""")]
        public void ThenTheUserSeeTheFollowingErrorMessage(string erromsj)
        {
            if (erromsj.ToLower().Contains("username"))
            {
                Assert.IsTrue(register.getUsernameErrorLbl().Displayed);
                Assert.IsTrue(register.getUsernameErrorLbl().Text.Contains(erromsj));
            }
            else if (erromsj.ToLower().Contains("password"))
            {
                Assert.IsTrue(register.getPasswordErrorLbl().Displayed);
                Assert.IsTrue(register.getPasswordErrorLbl().Text.Contains(erromsj));
            }
            else if (erromsj.ToLower().Contains("email"))
            {
                Assert.IsTrue(register.getEmailErrorLbl().Displayed);
                Assert.IsTrue(register.getEmailErrorLbl().Text.Contains(erromsj));
            }
        }

        [Then(@"The user see the following single error message: ""(.*)""")]
        public void ThenTheUserSeeTheFollowingSingleErrorMessage(string erromsj)
        {
            Assert.IsTrue(register.getSingleFieldErrorLbl().Displayed);
            Assert.IsTrue(register.getSingleFieldErrorLbl().Text.Contains(erromsj));
        }

        [AfterScenario, Scope(Feature = "Register")]
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
