using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FirstE2E
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://zero.webappsecurity.com/index.html");
            driver.FindElement(By.ClassName("signin")).Click();
            driver.FindElement(By.Id("user_login")).SendKeys("hola");
            driver.FindElement(By.Id("user_password")).SendKeys("hola");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            string errormsj = driver.FindElement(By.ClassName("alert-error")).Text;
            Assert.IsTrue(errormsj.Contains("Login and/or password are wrong"));
            driver.Dispose();
        }
    }
}
