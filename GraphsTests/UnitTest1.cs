using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using GraphsTests.Pages;
using GraphsFramework.Contexts;
using System.Collections.Generic;
using GraphsFramework.Utils;

namespace GraphsTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string _url = "https://www.highcharts.com/blog/news/146-highcharts-5th-anniversary/";

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            driver.SwitchTo().Frame(0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [TestCleanup]
        public void TestFinalize()
        {
            driver.Close();
        }

        [TestMethod]
        public void TestGraphOfGoogle()
        {
            GraphPage page = new GraphPage(driver);           
            page.OpenCloseGraphs[3].Click();
            page.OpenCloseGraphs[2].Click();
            GraphActions.MoveToPosition(page.GraphGoogleSearch, driver);
            Waiters.waitForVisibilityElement(By.CssSelector("g.highcharts-series.highcharts-series-0"), driver);
            List<int[]> list = GraphActions.CoordinatesOfPoints(page, page.PointsOfGraphGoogle, 6);
            GraphActions.MoveToPosition(list[0][0], 1, driver);
            for (int i = 0; i < list.Count-1; i++)
            {
                int offsetx = list[i + 1][0] - list[i][0];            
                var BestMonth = GraphActions.TextFromTspan(page, driver, "%");
                GraphStates.InformationAboutPercentsIsDisplayed(BestMonth);
                GraphActions.MoveToPosition2(offsetx, 0, driver);
                if (i == list.Count - 2)
                {
                    BestMonth = GraphActions.TextFromTspan(page, driver, "%");
                    GraphStates.InformationAboutPercentsIsDisplayed(BestMonth);
                }
            }
        }

        [TestMethod]
        public void TestGraphOfRevenue()
        {
            GraphPage page = new GraphPage(driver);
            page.OpenCloseGraphs[3].Click();
            page.OpenCloseGraphs[0].Click();
            GraphActions.MoveToPosition(page.Graphs, driver);
            Waiters.waitForVisibilityElement(By.CssSelector("g.highcharts-series.highcharts-series-1"), driver);
            List<int[]> list = GraphActions.CoordinatesOfPoints(page, page.PointsOfGraphRevenue, 2);
            GraphActions.MoveToPosition(list[0][0], 1, driver);
            for (int i = 0; i < list.Count - 1; i++)
            {
                int offsetx = list[i + 1][0] - list[i][0];
                var BestMonth = GraphActions.TextFromTspan(page, driver, "month");
                GraphStates.InformationAboutPercentsIsDisplayed(BestMonth);
                GraphActions.MoveToPosition2(offsetx, 0, driver);
                if (i == list.Count - 2)
                {
                    BestMonth = GraphActions.TextFromTspan(page, driver, "%");
                    GraphStates.InformationAboutPercentsIsDisplayed(BestMonth);
                }
            }
        }

        [TestMethod]
        public void TestGraphOfEmployees()
        {
            GraphPage page = new GraphPage(driver);
            List<int[]> list = GraphActions.CoordinatesOfPoints(page,page.PointsOfGraphEmployees,4);
            page.OpenCloseGraphs[2].Click();
            page.OpenCloseGraphs[0].Click();
            GraphActions.MoveToPosition(page.Graphs,driver);
            GraphActions.MoveToPosition(0, list[0][1], driver);          
            GraphActions.MoveToPosition(list[0][0], 0, driver);
            for (int i=0;i<list.Count-1;i++)
            {
                int offsetx = list[i + 1][0] - list[i][0];
                int offsety = list[i + 1][1] - list[i][1];
                GraphActions.MoveToPosition(0, offsety, driver);
                var CountOfEmployees = GraphActions.TextFromTspan(page, driver,"employees");
                GraphActions.MoveToPosition(offsetx, 0, driver);
                GraphStates.CheckPositionOfPoints(page,CountOfEmployees, list[i][1]);
            }
        }


        [TestMethod]
        public void TestAwardsAndReleasesIsShownInformation()
        {
            GraphPage page = new GraphPage(driver);
            foreach (var element in page.AwardsAndReleases)
            {
                GraphActions.MoveMouseToAward(page, driver, element);
                GraphStates.InformationIsDisplayed(page, page.TextInformation, driver);
            }
        }
    }     
}
