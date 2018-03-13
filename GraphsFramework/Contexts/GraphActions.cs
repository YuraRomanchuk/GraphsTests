using GraphsTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace GraphsFramework.Contexts
{
    public  class GraphActions
    {
        public static GraphPage MoveMouseToAward(GraphPage page, IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            return page;
        }

        public static string TextFromElement(GraphPage page, IList<IWebElement> list,IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("g.highcharts-tooltip > text ")));
            StringBuilder sb = new StringBuilder("");
            foreach (var element in list)
            {
                sb.Append(element.Text + "\n");
            }
            return sb.ToString();
        }


        public static string TextFromTspan(GraphPage page, IWebDriver driver, string word)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("g.highcharts-tooltip > text ")));
            return page.TextOfTspan.FindElement(By.XPath(".//*[contains(text(),'"+word+"')]")).Text;
        }

        public static List<int[]> CoordinatesOfPoints(GraphPage page, IWebElement element, int step)
        {
            var exactpoints = element.GetAttribute("d");
            exactpoints = Regex.Replace(exactpoints, "\\.", ",");
            exactpoints = Regex.Replace(exactpoints, "\\s[A-Z]\\s", " ");
            exactpoints = Regex.Replace(exactpoints, "[A-Z]\\s", "");
            var arr = exactpoints.Split(' ');

            List<int[]> list = new List<int[]>();

            for (int i = 0; i < arr.Length; i+=step)
            {
                var res = new int[2];
                double result;
                Double.TryParse(arr[i], out result);
                res[0] = Convert.ToInt32(result);
                Double.TryParse(arr[i + 1], out result);               
                res[1] = Convert.ToInt32(result);
                list.Add(res);
            }
            return list;
        }

        public static List<int> CoordinatesOfPointss(GraphPage page, IWebElement element, int step)
        {
            var exactpoints = element.GetAttribute("d");
            exactpoints = Regex.Replace(exactpoints, "\\.", ",");
            exactpoints = Regex.Replace(exactpoints, "\\s[A-Z]\\s", " ");
            exactpoints = Regex.Replace(exactpoints, "[A-Z]\\s", "");
            var arr = exactpoints.Split(' ');

            List<int> list = new List<int>();

            for (int i = 0; i < arr.Length; i+=2)
            {
                double result;
                Double.TryParse(arr[i], out result);
                list.Add(Convert.ToInt32(result));
            }
            return list;
        }

        public static void MoveToPosition(IWebElement element, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element, 0,0).Click().Build().Perform();           
        }

        public static void MoveToPosition(int x, int y, IWebDriver driver)
        {           
            int countx = 0;
            int county = 0;
            int stepx = x > 0 ? 1 : -1;
            int stepy = y > 0 ? 1 : -1;
            while (county < Math.Abs(y))
            {
                Actions action = new Actions(driver);
                action.MoveByOffset(0, stepy).Click().Build().Perform();              
                county++;
            }
            while (countx < Math.Abs(x))
            {
                Actions action = new Actions(driver);
                action.MoveByOffset(stepx, 0).Click().Build().Perform();
                countx++;               
            }
        }

        public static void MoveToPosition2(int x, int y, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(x, y).Click().Build().Perform();             
        }
    }
}
