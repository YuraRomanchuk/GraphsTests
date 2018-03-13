using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GraphsFramework.Utils
{
    public static class Waiters
    {
        public static void waitForClickableElement(By bylocator, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(bylocator));
        }

        public static void waitForVisibilityElement(By bylocator, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(bylocator));
        }
    }
}
