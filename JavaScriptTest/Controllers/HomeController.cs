using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using JavaScriptTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;

namespace JavaScriptTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Chart()
        {
            var chartViewModel = new ChartViewModel {
                barChart = GetBarChart(),
                pieChart = GetPieChart(),
                lineChart = GetLineChart()
            };
            

            return View(chartViewModel);
        }

        private Highcharts GetLineChart()
        {
            return new Highcharts("linechart")
                .InitChart(new Chart {
                    Type = ChartTypes.Line
                })
                .SetLegend(new Legend {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Right,
                    VerticalAlign = VerticalAligns.Middle
                })
                .SetSeries(new Series[] {
                    new Series {Name = "Installation", Data = new Data(new object[] {43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175})},
                    new Series {Name = "Manufacturing", Data = new Data(new object[] {24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434})},
                    new Series {Name = "Sales & Distribution", Data = new Data(new object[] {11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387})},
                    new Series {Name = "Project Development", Data = new Data(new object[] {null, null, 7988, 12169, 15112, 22452, 34400, 34227})},
                    new Series {Name = "Other", Data = new Data(new object[] {12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111})}
                });
        }

        private Highcharts GetPieChart()
        {
            return new Highcharts("piechart")
                .InitChart(new Chart
                {
                    Type = ChartTypes.Pie,
                })
                .SetPlotOptions(new PlotOptions {
                    Pie = new PlotOptionsPie
                    {
                        ShowInLegend = true
                    }
                })
                .SetSeries(new Series {
                    Name = "Brands",
                    Data = new Data(new object[] {
                        new { name = "first", y = 15},
                        new { name = "second", y = 25},
                        new { name = "third", y = 45},
                        new { name = "fourth", y = 85}
                    })
                });
        }

        private Highcharts GetBarChart()
        {
            return new DotNet.Highcharts.Highcharts("barchart")
                .SetPlotOptions(new PlotOptions
                {
                    Series = new PlotOptionsSeries
                    {
                        Point = new PlotOptionsSeriesPoint
                        {
                            Events = new PlotOptionsSeriesPointEvents
                            {
                                Click = @"function (event) { 
                                    console.log(event);
                                    alert('hey');
                                }"
                            }
                        }
                    }
                })
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                })
                .SetSeries(new Series
                {
                    Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                })
                .InitChart(new Chart
                {
                    DefaultSeriesType = ChartTypes.Column,
                    Height = 500,
                    Events = new ChartEvents
                    {
                        Click = @"function (event) { 
                                    console.log(event);
                                    alert('hey');
                                }"
                    }
                });
        }
    }
}
