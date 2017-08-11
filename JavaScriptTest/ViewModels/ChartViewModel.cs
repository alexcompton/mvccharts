using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaScriptTest.ViewModels
{
    public class ChartViewModel
    {
        public Highcharts barChart { get; set; }
        public Highcharts lineChart { get; set; }
        public Highcharts pieChart { get; set; }
    }
}