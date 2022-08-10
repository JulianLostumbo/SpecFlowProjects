using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EAAPP.Util
{
    public class Util
    {
        public static void WaitForElement(By element, IWebDriver driver, int seconds)
        {
            var waitTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            waitTitle.Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}
