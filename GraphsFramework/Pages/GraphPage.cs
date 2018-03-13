using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace GraphsTests.Pages
{
    public class GraphPage
    {
        private IWebDriver _driver;

        public GraphPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-legend-item > text > tspan")]
        public IList<IWebElement> OpenCloseGraphs;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-2")]
        public IWebElement GraphEmployees;
        
        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-1.")]
        public IWebElement GraphRevenue;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-0")]
        public IWebElement GraphGoogleSearch;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-label.highcharts-point > text")]
        public IList<IWebElement> AwardsAndReleases;
        
        [FindsBy(How = How.CssSelector, Using = " g.highcharts-tooltip > text > tspan")]
        public IList<IWebElement> TextInformation;

        [FindsBy(How = How.CssSelector, Using = " g.highcharts-tooltip > text")]
        public IWebElement TextOfTspan;

        [FindsBySequence]
        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-2")]
        [FindsBy(How = How.CssSelector, Using = "path[fill=none]")]
        public IWebElement PointsOfGraphEmployees;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-1 path[fill=none]")]
        public IWebElement PointsOfGraphRevenue;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-series.highcharts-series-0 .highcharts-graph")]
        public IWebElement PointsOfGraphGoogle;

        [FindsBy(How = How.ClassName, Using = "highcharts-plot-background")]
        public IWebElement Graphs;

        [FindsBy(How = How.CssSelector, Using = ".highcharts-tooltip[visibility=visible]")]
        public IWebElement Tooltip;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'highcharts-yaxis-labels')]/*")]
        public IList<IWebElement> YaxisLabels;
    }
}
