using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace GoogleSearch
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            //{
            //    Url = "http://the-internet.herokuapp.com/"
            //};
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            Assert.IsTrue(driver.Title == "The Internet");
            driver.Dispose();
        }
    }
}
