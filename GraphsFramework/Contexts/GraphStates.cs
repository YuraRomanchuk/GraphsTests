using GraphsTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace GraphsFramework.Contexts
{
    public static class GraphStates
    {
        public static void InformationIsDisplayed(GraphPage page, IList<IWebElement> list,IWebDriver driver)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GraphActions.TextFromElement(page,list,driver)));
        }

        public static void InformationAboutPercentsIsDisplayed(string text)
        {
            string percents = Regex.Match(text, "\\d+").Value;
            Console.WriteLine(percents);
            int percent = Convert.ToInt32(percents);
            Console.WriteLine(percent);
            Assert.IsTrue(percent>=0);
        }

        public static void CheckPositionOfPoints(GraphPage page,string employees, int yposition)
        {
            List<int> list = new List<int>();
            foreach (var element in page.YaxisLabels)
            {
                list.Add(Convert.ToInt32(element.GetAttribute("y")));
            }
            int GraphSize = list.First() - list.Last();
            
            string counts = Regex.Match(employees, "\\d+").Value;
            int count = Convert.ToInt32(counts);
            double OneEmployeeSize = (double)GraphSize /15;
            int EmployeeSize = Convert.ToInt32(OneEmployeeSize * (15-count));
            Assert.IsTrue(EmployeeSize==yposition);
        }

        public static void ElementIsShown(IWebElement element)
        {
            Assert.IsTrue(element.Displayed);
        }

        public static void ElementIsHidden(IWebElement element)
        {
            Assert.IsFalse(element.Displayed);
        }
    }
}
